//
//  SlideEditorEngine.m
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "SlideEditorEngine.h"
#import "AppDelegate.h"

@implementation SlideEditorEngine

- (id)initEmpty:(id)slidePoolDelegate
{
    if(self=[super init])
    {
        slidePoolSelectionDelegate=slidePoolDelegate;
        _slidePoolDelegate=[[EditorSlideTableDelegate alloc] initWithList:[NSArray array] delegate:self];
        _slideSetDelegate=[[EditorSlideTableDelegate alloc] initWithList:[NSArray array] delegate:nil];
        _selectedIndex=-1;
        return self;
    }
    else
    {
        return nil;
    }
}

- (void)openSetForEdit:(SlideSet *)slideSet
{
    openSet=slideSet;
    [self populateFields];
}

- (void)openNewSetForEdit
{
    openSet=[[SlideSet alloc] initEmptySet];
    [self populateFields];
}

- (void)populateFields
{
    [_slidePoolDelegate clearList];
    [_slideSetDelegate clearList];
    _slideTitle=openSet.title;
    _slideByline=openSet.byline;
    _slideCopyright=openSet.copyright;
    _slideChorus=openSet.chorus;
    for(uint x=0;x<[openSet.texts count];x++)
    {
        NSString* text=[openSet.texts objectAtIndex:x];
        [_slidePoolDelegate addItem:[[EditorSlide alloc] initWithIndex:x chorus:x==openSet.chorus chorusDefined:openSet.chorus!=-1 text:text linesperslide:[openSet.linesperslide objectAtIndex:x]]];
    }
    for(uint x=0;x<[openSet.order count];x++)
    {
        NSNumber* ord=[openSet.order objectAtIndex:x];
        EditorSlide* slide=[_slidePoolDelegate getItem:[ord integerValue]];
        [_slideSetDelegate addItem:[[SlideSetPlaceholder alloc] initWithId:slide.slideId andName:slide.description]];
    }
}

- (NSString*)getTextForIndex:(NSInteger)index
{
    EditorSlide* slide=[_slidePoolDelegate getItem:index];
    if(!slide)
    {
        return [NSString string];
    }
    return [NSString stringWithString:slide.slideText];
}

- (NSInteger)getLpsForIndex:(NSInteger)index
{
    EditorSlide* slide=[_slidePoolDelegate getItem:index];
    if(!slide)
    {
        return 4;
    }
    return [slide.linesperslide integerValue];
}

- (void)addSlideToOrder:(NSInteger)index
{
    if(index>=0&&index<[_slidePoolDelegate getListLength])
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:index];
        [_slideSetDelegate addItem:[[SlideSetPlaceholder alloc] initWithId:slide.slideId andName:slide.description]];
    }
}

- (void)removeSlideFromOrder:(NSInteger)index
{
    if(index>=0&&index<[_slideSetDelegate getListLength])
    {
        [_slideSetDelegate removeItem:index];
    }
}

- (void)newSlide
{
    [_slidePoolDelegate addItem:[[EditorSlide alloc] initWithIndex:[_slidePoolDelegate getListLength] chorus:NO chorusDefined:_slideChorus!=-1 text:[NSString string] linesperslide:[NSNumber numberWithInt:4]]];
}

- (void)deleteSlide:(NSInteger)index
{
    if(index>=0&&index<[_slidePoolDelegate getListLength])
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:index];
        if(slide.isChorus)
        {
            _slideChorus=-1;
        }
        [_slidePoolDelegate removeItem:index];
        NSString* slideId=slide.slideId;
        for(long x=[_slideSetDelegate getListLength]-1;x>=0;x--)
        {
            SlideSetPlaceholder* slide=[_slideSetDelegate getItem:x];
            if([slide.setId compare:slideId]==NSOrderedSame)
            {
                [_slideSetDelegate removeItem:x];
            }
        }
        [self refreshIndices];
    }
}

- (void)reorderSlideUp:(NSInteger)index
{
    if(index>0&&index<[_slideSetDelegate getListLength])
    {
        [_slideSetDelegate reorderItemUp:index];
    }
}

- (void)reorderSlideDown:(NSInteger)index
{
    if(index>=0&&index<[_slideSetDelegate getListLength]-1)
    {
        [_slideSetDelegate reorderItemDown:index];
    }
}

- (void)setChorus:(NSInteger)index
{
    if(index>=0&&index<[_slidePoolDelegate getListLength]&&_slideChorus==-1)
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:index];
        slide.isChorus=YES;
        [_slidePoolDelegate reorderItemToTop:index];
        _slideChorus=0;
        [self refreshIndices];
    }
}

- (void)setTextForSelectedSlide:(NSString *)text
{
    if(_selectedIndex>=0&&_selectedIndex<[_slidePoolDelegate getListLength])
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:_selectedIndex];
        slide.slideText=[NSMutableString stringWithString:text];
    }
}

- (void)setLpsForSelectedSlide:(NSInteger)lps
{
    if(_selectedIndex>=0&&_selectedIndex<[_slidePoolDelegate getListLength])
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:_selectedIndex];
        slide.linesperslide=[NSNumber numberWithInteger:lps];
    }
}

- (void)refreshIndices
{
    NSMutableDictionary* indexLookup=[NSMutableDictionary dictionary];
    for(uint x=0;x<[_slidePoolDelegate getListLength];x++)
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:x];
        slide.slideIndex=x;
        slide.chorusDefined=_slideChorus!=-1;
        [indexLookup setObject:slide.description forKey:slide.slideId];
    }
    for(uint x=0;x<[_slideSetDelegate getListLength];x++)
    {
        SlideSetPlaceholder* slide=[_slideSetDelegate getItem:x];
        slide.name=[indexLookup valueForKey:slide.setId];
    }
}

- (SlideSet*)getSlideSet
{
    openSet.title=[NSString stringWithString:_slideTitle];
    openSet.byline=[NSString stringWithString:_slideByline];
    openSet.copyright=[NSString stringWithString:_slideCopyright];
    openSet.chorus=_slideChorus;
    [openSet.texts removeAllObjects];
    [openSet.order removeAllObjects];
    [openSet.linesperslide removeAllObjects];
    NSMutableDictionary* slideLookup=[NSMutableDictionary dictionary];
    for(uint x=0;x<[_slidePoolDelegate getListLength];x++)
    {
        EditorSlide* slide=[_slidePoolDelegate getItem:x];
        [openSet.texts addObject:[NSString stringWithString:slide.slideText]];
        [openSet.linesperslide addObject:[NSNumber numberWithInteger:[slide.linesperslide integerValue]]];
        [slideLookup setObject:[NSNumber numberWithInt:x] forKey:[NSString stringWithString:slide.slideId]];
    }
    for(uint x=0;x<[_slideSetDelegate getListLength];x++)
    {
        SlideSetPlaceholder* slide=[_slideSetDelegate getItem:x];
        NSNumber* index=[slideLookup objectForKey:slide.setId];
        [openSet.order addObject:[NSNumber numberWithInteger:[index integerValue]]];
    }
    return openSet;
}

- (void)selectionDidChange
{
    if(slidePoolSelectionDelegate && [slidePoolSelectionDelegate respondsToSelector:@selector(editorPoolSelectedChanged)])
    {
        [slidePoolSelectionDelegate editorPoolSelectedChanged];
    }
}

@end
