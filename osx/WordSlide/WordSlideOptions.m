//
//  WordSlideOptions.m
//  WordSlide
//
//  Created by Jonathan Ray on 8/29/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "WordSlideOptions.h"

@implementation WordSlideOptions

- (id)initWithDefaults
{
    self=[super init];
    if(self)
    {
        _titleFont=[NSFont labelFontOfSize:42];
        _textFont=[NSFont labelFontOfSize:36];
        _bylineFont=[NSFont labelFontOfSize:16];
        _dotFont=[NSFont labelFontOfSize:14];
        _titleStart=100;
        _textStart=200;
        _titleTextSpace=50;
        _dotSpace=50;
        _endOfSetString=@"..";
        _endOfShowString=@"...";
    }
    return self;
}

@end
