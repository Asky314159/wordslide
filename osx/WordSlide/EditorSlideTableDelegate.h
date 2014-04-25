//
//  EditorSlideTableDelegate.h
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface EditorSlideTableDelegate : NSObject <NSTableViewDataSource, NSTableViewDelegate>
{
    NSMutableArray* slideList;
    id delegate;
}

- (id)initWithList:(NSArray*)initialList delegate:(id)selectedDelegate;
- (NSInteger)getListLength;
- (id)getItem:(NSInteger)index;
- (void)addItem:(id)item;
- (void)removeItem:(NSInteger)index;
- (void)replaceItem:(NSInteger)index WithItem:(id)item;
- (void)reorderItemUp:(NSInteger)index;
- (void)reorderItemDown:(NSInteger)index;
- (void)reorderItemToTop:(NSInteger)index;
- (void)clearList;

@end
