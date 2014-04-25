//
//  SlideTableDelegate.m
//  WordSlide
//
//  Created by Jonathan Ray on 8/19/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "SlideTableDelegate.h"
#import "SlideSetPlaceholder.h"

@implementation SlideTableDelegate

- (id)initWithList:(NSArray*)initialList
{
    if(self=[super init])
    {
        slideList=[NSMutableArray arrayWithArray:initialList];
        return self;
    }
    else
    {
        return nil;
    }
}
- (NSInteger)getListLength
{
    return slideList.count;
}

- (id)getItem:(NSInteger)index
{
    if(index<0||index>=slideList.count)return nil;
    return [slideList objectAtIndex:index];
}

- (void)addItem:(id)item
{
    [slideList addObject:item];
}

- (void)removeItem:(NSInteger)index
{
    if(index>=0&&index<slideList.count)
    {
        [slideList removeObjectAtIndex:index];
    }
}

- (void)reorderItemUp:(NSInteger)index
{
    if(index>0&&index<slideList.count)
    {
        [slideList exchangeObjectAtIndex:index withObjectAtIndex:index-1];
    }
}

- (void)reorderItemDown:(NSInteger)index
{
    if(index>=0&&index<slideList.count-1)
    {
        [slideList exchangeObjectAtIndex:index withObjectAtIndex:index+1];
    }
}

- (void)clearList
{
    [slideList removeAllObjects];
}

- (void)sortItems
{
    [slideList sortUsingComparator:^NSComparisonResult(id obj1, id obj2) {
        SlideSetPlaceholder* p1=(SlideSetPlaceholder*)obj1;
        SlideSetPlaceholder* p2=(SlideSetPlaceholder*)obj2;
        return [[p1.name stringByTrimmingCharactersInSet:[NSCharacterSet punctuationCharacterSet]] localizedStandardCompare:[p2.name stringByTrimmingCharactersInSet:[NSCharacterSet punctuationCharacterSet]]];
    }];
}

- (void)replaceList:(NSArray *)newList
{
    [self clearList];
    [slideList addObjectsFromArray:newList];
}

- (void)replaceItemAtIndex:(NSInteger)index withItem:(id)item
{
    if(index>=0&&index<slideList.count)
    {
        [slideList replaceObjectAtIndex:index withObject:item];
    }
}

- (NSInteger)numberOfRowsInTableView:(NSTableView *)tableView
{
    return slideList.count;
}

- (NSView *)tableView:(NSTableView *)tableView viewForTableColumn:(NSTableColumn *)tableColumn row:(NSInteger)row
{
    NSTextField *result = [tableView makeViewWithIdentifier:@"SlideTableView" owner:self];
    if(result==nil)
    {
        result=[[NSTextField alloc] initWithFrame:NSMakeRect(0, 0, tableColumn.width, 10)];
        [result setEditable:false];
        [result setSelectable:false];
        [result setBezeled:false];
        [result setBackgroundColor:[NSColor clearColor]];
        result.identifier=@"SlideTableView";
    }
    result.stringValue=[slideList objectAtIndex:row];
    return result;
}

@end
