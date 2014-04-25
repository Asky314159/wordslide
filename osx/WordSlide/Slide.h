//
//  Slide.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/29/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Slide : NSObject

@property (readwrite) NSString* title;
@property (readwrite) NSString* byline;
@property (readwrite) NSString* copyright;
@property (readwrite) NSString* text;
@property (readwrite) BOOL endOfSet;
@property (readwrite) BOOL endOfShow;
@property (readwrite) BOOL blank;

@end
