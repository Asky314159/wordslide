//
//  SlideTableDelegate.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/19/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SlideTableDelegate : NSObject <NSTableViewDataSource, NSTableViewDelegate>
{
    NSMutableArray *slideList;
}

- (id)initWithList:(NSArray*)initialList;
- (NSInteger)getListLength;
- (id)getItem:(NSInteger)index;
- (void)addItem:(id)item;
- (void)removeItem:(NSInteger)index;
- (void)reorderItemUp:(NSInteger)index;
- (void)reorderItemDown:(NSInteger)index;
- (void)clearList;
- (void)sortItems;
- (void)replaceList:(NSArray*)newList;
- (void)replaceItemAtIndex:(NSInteger)index withItem:(id)item;
- (NSInteger)numberOfRowsInTableView:(NSTableView *)tableView;
- (NSView *)tableView:(NSTableView *)tableView viewForTableColumn:(NSTableColumn *)tableColumn row:(NSInteger)row;

@end
