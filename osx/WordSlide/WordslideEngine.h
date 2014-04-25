//
//  WordslideEngine.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/19/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SlideTableDelegate.h"
#import "Slide.h"
#import "SlideSet.h"
#import "SlideSetPlaceholder.h"

@interface WordslideEngine : NSObject
{
    NSMutableDictionary* slideLibrary;
    NSMutableArray* slideShow;
    uint currentSlideSet;
    SlideSetPlaceholder* blankSlideId;
}

- (id)initWithStuff;
- (void)loadSavedData;
- (void)addRowToShow:(NSInteger)row;
- (void)addBlankSlideToShow;
- (void)removeRowFromShow:(NSInteger)row;
- (void)reorderShowRowUp:(NSInteger)row;
- (void)reorderShowRowDown:(NSInteger)row;
- (void)clearShow;
- (BOOL)beginShow;
- (void)advanceSlide;
- (void)unadvanceSlide;
- (Slide*)getCurrentSlide;
- (NSString*)getPoolId:(NSInteger)row;
- (SlideSet*)getSlideSetForId:(NSString*)setId;
- (void)addSlideSet:(SlideSet*)slideSet;

@property (readonly) SlideTableDelegate *slidePoolDelegate;
@property (readonly) SlideTableDelegate *slideShowDelegate;

@end
