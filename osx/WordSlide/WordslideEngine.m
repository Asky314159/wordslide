//
//  WordslideEngine.m
//  WordSlide
//
//  Created by Jonathan Ray on 8/19/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "WordslideEngine.h"

@implementation WordslideEngine

- (id)initWithStuff
{
    if(self=[super init])
    {
        [self loadSavedData];
        SlideSet* blankSet=[[SlideSet alloc] initBlankSet];
        blankSlideId=[[SlideSetPlaceholder alloc] initWithId:blankSet.setId andName:@"[Blank Slide]"];
        [slideLibrary setObject:blankSet forKey:blankSet.setId];
        NSMutableArray* slidePool = [NSMutableArray array];
        [slideLibrary enumerateKeysAndObjectsUsingBlock:^(id key, id obj, BOOL *stop) {
            SlideSet* set=(SlideSet*)obj;
            if(![[set setId] isEqualToString:[blankSlideId setId]])
            {
                [slidePool addObject:[[SlideSetPlaceholder alloc] initWithId:[set setId] andName:[set title]]];
            }
        }];
        slidePoolDelegate=[[SlideTableDelegate alloc] initWithList:slidePool];
        [slidePoolDelegate sortItems];
        slideShowDelegate=[[SlideTableDelegate alloc] initWithList:[NSArray array]];
        slideShow=[NSMutableArray array];
        return self;
    }
    else
    {
        return nil;
    }
}

- (void)loadSavedData
{
    slideLibrary=[NSMutableDictionary dictionary];
    NSFileManager* fileManager=[NSFileManager defaultManager];
    BOOL isDir;
    if(![fileManager fileExistsAtPath:[WordslideEngine getSlideDataPath] isDirectory:&isDir])
    {
        NSError* error;
        [fileManager createDirectoryAtPath:[WordslideEngine getSlideDataPath] withIntermediateDirectories:TRUE attributes:nil error:&error];
    }
    NSArray* slideFiles=[fileManager contentsOfDirectoryAtPath:[WordslideEngine getSlideDataPath] error:nil];
    for(id file in slideFiles)
    {
        if([file isKindOfClass:[NSString class]])
        {
            NSString* fileString=(NSString*)file;
            if([fileString hasSuffix:@".slx"])
            {
                @try
                {
                    NSString* filePath=[[WordslideEngine getSlideDataPath] stringByAppendingPathComponent:fileString];
                    SlideSet* newSet=[NSKeyedUnarchiver unarchiveObjectWithFile:filePath];
                    NSError* error;
                    [fileManager removeItemAtPath:filePath error:&error];
                    [self saveSlideSet:newSet];
                    [slideLibrary setObject:newSet forKey:newSet.setId];
                }
                @catch(NSException* e)
                {
                    
                }
            }
            else if ([fileString hasSuffix:@".slj"])
            {
                @try
                {
                    NSData* data=[NSData dataWithContentsOfFile:[[WordslideEngine getSlideDataPath] stringByAppendingPathComponent:fileString]];
                    SlideSet* newSet=[SlideSet decodeJson:data];
                    [slideLibrary setObject:newSet forKey:newSet.setId];
                }
                @catch(NSException* e)
                {
                    
                }
            }
        }
    }
}

- (void)saveSlideSet:(SlideSet*)slideSet
{
    NSFileManager* fileManager=[NSFileManager defaultManager];
    BOOL isDir;
    if(![fileManager fileExistsAtPath:[WordslideEngine getSlideDataPath] isDirectory:&isDir])
    {
        NSError* error;
        [fileManager createDirectoryAtPath:[WordslideEngine getSlideDataPath] withIntermediateDirectories:TRUE attributes:nil error:&error];
    }
    NSString* savePath=[[WordslideEngine getSlideDataPath] stringByAppendingPathComponent:[slideSet.setId stringByAppendingPathExtension:@"slj"]];
    NSData* data = [SlideSet encodeJson:slideSet];
    [data writeToFile:savePath atomically:TRUE];
    //[NSKeyedArchiver archiveRootObject:slideSet toFile:savePath];
}

- (void)addRowToShow:(NSInteger)row
{
    id item=[slidePoolDelegate getItem:row];
    if(item!=nil)
    {
        [slideShowDelegate addItem:item];
    }
}

- (void)addBlankSlideToShow
{
    [slideShowDelegate addItem:blankSlideId];
}

- (void)removeRowFromShow:(NSInteger)row
{
    [slideShowDelegate removeItem:row];
}

- (void)reorderShowRowUp:(NSInteger)row
{
    [slideShowDelegate reorderItemUp:row];
}

- (void)reorderShowRowDown:(NSInteger)row
{
    [slideShowDelegate reorderItemDown:row];
}

- (void)clearShow
{
    [slideShowDelegate clearList];
}

- (BOOL)beginShow
{
    [slideShow removeAllObjects];
    currentSlideSet=0;
    if([slideShowDelegate getListLength]<1)
    {
        return FALSE;
    }
    for(int x=0;x<[slideShowDelegate getListLength];x++)
    {
        SlideSetPlaceholder* setPlaceholder=(SlideSetPlaceholder*)[slideShowDelegate getItem:x];
        [slideShow addObject:[slideLibrary objectForKey:setPlaceholder.setId]];
    }
    [[slideShow objectAtIndex:currentSlideSet] goToBeginning];
    return TRUE;
}

- (void)advanceSlide
{
    SlideSet* currentSet=[slideShow objectAtIndex:currentSlideSet];
    if(![currentSet advanceSlide]&&currentSlideSet<[slideShow count]-1)
    {
        currentSlideSet++;
        currentSet=[slideShow objectAtIndex:currentSlideSet];
        [currentSet goToBeginning];
    }
}

- (void)unadvanceSlide
{
    SlideSet* currentSet=[slideShow objectAtIndex:currentSlideSet];
    if(![currentSet unadvanceSlide]&&currentSlideSet>0)
    {
        currentSlideSet--;
        currentSet=[slideShow objectAtIndex:currentSlideSet];
        [currentSet goToEnd];
    }
}

- (Slide*)getCurrentSlide
{
    SlideSet* currentSet=[slideShow objectAtIndex:currentSlideSet];
    Slide* ret=[currentSet getCurrentSlide];
    if(ret.endOfSet&&currentSlideSet>=[slideShow count]-1)
    {
        ret.endOfShow=TRUE;
    }
    return ret;
}

- (NSString*)getPoolId:(NSInteger)row
{
    id poolItem=[slidePoolDelegate getItem:row];
    if(poolItem!=nil)
    {
        return [poolItem setId];
    }
    return [NSString string];
}

- (SlideSet*)getSlideSetForId:(NSString *)setId
{
    return [slideLibrary objectForKey:setId];
}

- (void)addSlideSet:(SlideSet*)slideSet
{
    [slideLibrary setObject:slideSet forKey:slideSet.setId];
    [self saveSlideSet:slideSet];
    
    NSMutableArray* slidePool = [NSMutableArray array];
    [slideLibrary enumerateKeysAndObjectsUsingBlock:^(id key, id obj, BOOL *stop) {
        SlideSet* set=(SlideSet*)obj;
        if(![[set setId] isEqualToString:[blankSlideId setId]])
        {
            [slidePool addObject:[[SlideSetPlaceholder alloc] initWithId:[set setId] andName:[set title]]];
        }
    }];
    [slidePoolDelegate replaceList:slidePool];
    [slidePoolDelegate sortItems];
    
    for(uint x=0;x<[slideShowDelegate getListLength];x++)
    {
        SlideSetPlaceholder* set=[slideShowDelegate getItem:x];
        if([set.setId compare:slideSet.setId]==NSOrderedSame)
        {
            set.name=[NSString stringWithString:slideSet.title];
            [slideShowDelegate replaceItemAtIndex:x withItem:set];
        }
    }
}

- (void)deleteSlideSet:(NSString *)setId
{
    [slideLibrary removeObjectForKey:setId];
    
    for (NSInteger x=[slidePoolDelegate getListLength]; x>=0; x--)
    {
        SlideSetPlaceholder *placeholder=[slidePoolDelegate getItem:x];
        if([placeholder.setId isEqualToString:setId])
        {
            [slidePoolDelegate removeItem:x];
        }
    }
    
    for (NSInteger x=[slideShowDelegate getListLength]; x>=0; x--)
    {
        SlideSetPlaceholder *placeholder=[slideShowDelegate getItem:x];
        if([placeholder.setId isEqualToString:setId])
        {
            [slideShowDelegate removeItem:x];
        }
    }
    
    NSString* path=[[WordslideEngine getSlideDataPath] stringByAppendingPathComponent:[setId stringByAppendingPathExtension:@"slx"]];
    NSError *error;
    [[NSFileManager defaultManager] removeItemAtPath:path error:&error];
}

+ (NSString*)getSavedDataPath
{
    NSArray* basePath=NSSearchPathForDirectoriesInDomains(NSApplicationSupportDirectory, NSUserDomainMask, TRUE);
    return [[basePath objectAtIndex:0] stringByAppendingPathComponent:@"WordSlide"];
}

+ (NSString*)getSlideDataPath
{
    return [[self getSavedDataPath] stringByAppendingPathComponent:@"slides"];
}

@synthesize slidePoolDelegate;
@synthesize slideShowDelegate;

@end
