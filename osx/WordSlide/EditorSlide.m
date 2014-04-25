//
//  EditorSlide.m
//  WordSlide
//
//  Created by Jonathan Ray on 9/11/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "EditorSlide.h"

@implementation EditorSlide

- (id)initWithIndex:(NSInteger)index chorus:(BOOL)chorus chorusDefined:(BOOL)defined text:(NSString*)text linesperslide:(NSNumber*)lines
{
    self=[super init];
    if(self)
    {
        _slideId=[EditorSlide generateNewSlideId];
        _slideIndex=index;
        _isChorus=chorus;
        _chorusDefined=defined;
        _slideText=[NSMutableString stringWithString:text];
        _linesperslide=[NSNumber numberWithInteger:[lines integerValue]];
    }
    return self;
}

- (id)initWithSlide:(EditorSlide *)slide
{
    self=[super init];
    if(self)
    {
        _slideId=[NSString stringWithString:[slide slideId]];
        _slideIndex=[slide slideIndex];
        _isChorus=[slide isChorus];
        _chorusDefined=[slide chorusDefined];
        _slideText=[NSMutableString stringWithString:[slide slideText]];
        _linesperslide=[NSNumber numberWithInteger:[[slide linesperslide] integerValue]];
    }
    return self;
}

- (id)copyWithZone:(NSZone *)zone
{
    return [[[self class] allocWithZone:zone] initWithSlide:self];
}

- (NSString*)description
{
    if(_isChorus)
    {
        return @"Chorus";
    }
    else
    {
        return [NSString stringWithFormat:@"Verse %ld",_chorusDefined?(long)_slideIndex:(long)_slideIndex+1];
    }
}

+ (NSString*)generateNewSlideId
{
    return [[NSProcessInfo processInfo] globallyUniqueString];
}

@end
