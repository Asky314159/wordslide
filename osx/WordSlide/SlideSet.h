//
//  SlideSet.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/21/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Slide.h"

@interface SlideSet : NSObject <NSCoding>
{
    bool blank;
}

@property (readonly) NSMutableString* setId;
@property (readwrite) NSMutableString* title;
@property (readwrite) NSMutableString* byline;
@property (readwrite) NSMutableString* copyright;
@property (readwrite) NSMutableArray* texts;
@property (readwrite) NSMutableArray* order;
@property (readwrite) int chorus;
@property (readwrite) NSMutableArray* linesperslide;
- (id)initEmptySet;
- (id)initBlankSet;
+ (NSString*)generateNewSetId;
@property (readwrite) unsigned long currentSlide;
@property (readwrite) unsigned long currentSubSlide;
- (Slide*)getCurrentSlide;
- (BOOL)advanceSlide;
- (BOOL)unadvanceSlide;
- (void)goToBeginning;
- (void)goToEnd;
+ (SlideSet*) decodeJson:(NSData*) data;
+ (NSData*) encodeJson:(SlideSet*) slideSet;

@end
