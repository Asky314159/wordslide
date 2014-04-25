//
//  SlideSetPlaceholder.h
//  WordSlide
//
//  Created by Jonathan Ray on 8/29/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface SlideSetPlaceholder : NSObject
{
    
}

@property (readonly) NSString* setId;
@property (readwrite) NSString* name;
- (id)initWithId:(NSString*)newId andName:(NSString*)newName;
- (id)copyWithZone:(NSZone*)zone;
- (NSString*)description;

@end

