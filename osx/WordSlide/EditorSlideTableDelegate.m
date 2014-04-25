//
//  EditorSlideTableDelegate.m
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "EditorSlideTableDelegate.h"
#import "SlideEditorEngine.h"

@implementation EditorSlideTableDelegate

- (id)initWithList:(NSArray *)initialList delegate:(id)selectedDelegate
{
    if(self=[super init])
    {
        slideList=[NSMutableArray arrayWithArray:initialList];
        delegate=selectedDelegate;
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

- (void)replaceItem:(NSInteger)index WithItem:(id)item
{
    if(index>=0&&index<slideList.count)
    {
        
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

- (void)reorderItemToTop:(NSInteger)index
{
    if(index>0&&index<slideList.count)
    {
        id item=[slideList objectAtIndex:index];
        [slideList removeObjectAtIndex:index];
        [slideList insertObject:item atIndex:0];
    }
}

- (void)clearList
{
    [slideList removeAllObjects];
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

- (void)tableViewSelectionDidChange:(NSNotification *)notification
{
    if(delegate && [delegate respondsToSelector:@selector(selectionDidChange)])
    {
        [delegate selectionDidChange];
    }
}

@end
