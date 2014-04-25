//
//  WordSlideOptions.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/29/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface WordSlideOptions : NSObject

- (id)initWithDefaults;
@property (readonly) NSFont* titleFont;
@property (readonly) NSFont* textFont;
@property (readonly) NSFont* bylineFont;
@property (readonly) NSFont* dotFont;
@property (readonly) int titleStart;
@property (readonly) int textStart;
@property (readonly) int titleTextSpace;
@property (readonly) int dotSpace;
@property (readonly) NSString* endOfSetString;
@property (readonly) NSString* endOfShowString;

@end
