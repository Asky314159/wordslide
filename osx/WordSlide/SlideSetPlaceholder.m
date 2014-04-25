//
//  SlideSetPlaceholder.m
//  WordSlide
//
//  Created by Jonathan Ray on 8/29/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "SlideSetPlaceholder.h"

@implementation SlideSetPlaceholder

- (id)initWithId:(NSString*)newId andName:(NSString*)newName
{
    self=[super init];
    if(self)
    {
        _setId=newId;
        _name=newName;
    }
    return self;
}

- (id)copyWithZone:(NSZone *)zone
{
    SlideSetPlaceholder* placeholder=[[self class] allocWithZone:zone];
    placeholder->_name=self.name;
    placeholder->_setId=self.setId;
    return placeholder;
}

- (NSString*)description
{
    return _name;
}

@end