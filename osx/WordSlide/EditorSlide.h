//
//  EditorSlide.h
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface EditorSlide : NSObject

- (id)initWithIndex:(NSInteger)index chorus:(BOOL)chorus chorusDefined:(BOOL)defined text:(NSString*)text linesperslide:(NSNumber*)lines;
- (id)initWithSlide:(EditorSlide*)slide;
- (id)copyWithZone:(NSZone*)zone;
- (NSString*)description;
+ (NSString*)generateNewSlideId;

@property (readonly) NSString* slideId;
@property (readwrite) BOOL isChorus;
@property (readwrite) NSInteger slideIndex;
@property (readwrite) BOOL chorusDefined;
@property (readwrite) NSMutableString* slideText;
@property (readwrite) NSNumber* linesperslide;

@end
