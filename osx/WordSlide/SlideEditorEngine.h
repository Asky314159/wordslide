//
//  SlideEditorEngine.h
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SlideSet.h"
#import "EditorSlide.h"
#import "SlideSetPlaceholder.h"
#import "EditorSlideTableDelegate.h"

@interface SlideEditorEngine : NSObject
{
    SlideSet* openSet;
    id slidePoolSelectionDelegate;
}

- (id)initEmpty:(id)slidePoolDelegate;
- (void)openSetForEdit:(SlideSet*)slideSet;
- (void)openNewSetForEdit;
- (NSString*)getTextForIndex:(NSInteger)index;
- (NSInteger)getLpsForIndex:(NSInteger)index;
- (void)selectionDidChange;
- (void)addSlideToOrder:(NSInteger)index;
- (void)removeSlideFromOrder:(NSInteger)index;
- (void)newSlide;
- (void)deleteSlide:(NSInteger)index;
- (void)reorderSlideUp:(NSInteger)index;
- (void)reorderSlideDown:(NSInteger)index;
- (void)setChorus:(NSInteger)index;
- (void)setTextForSelectedSlide:(NSString*)text;
- (void)setLpsForSelectedSlide:(NSInteger)lps;
- (SlideSet*)getSlideSet;

@property (readwrite) NSInteger selectedIndex;
@property (readwrite) NSString* slideTitle;
@property (readwrite) NSString* slideByline;
@property (readwrite) NSString* slideCopyright;
@property (readonly) int slideChorus;
@property (readonly) EditorSlideTableDelegate* slidePoolDelegate;
@property (readonly) EditorSlideTableDelegate* slideSetDelegate;

@end
