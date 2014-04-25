//
//  SlideSet.m
//  WordSlide
//
//  Created by Jonathan Ray on 8/21/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "SlideSet.h"

@implementation SlideSet

- (id)initEmptySet
{
    self=[super init];
    if(self)
    {
        _setId=[[NSMutableString alloc] initWithString:[SlideSet generateNewSetId]];
        _title=[[NSMutableString alloc] init];
        _byline=[[NSMutableString alloc] init];
        _copyright=[[NSMutableString alloc] init];
        _texts=[[NSMutableArray alloc] init];
        _order=[[NSMutableArray alloc] init];
        _chorus=-1;
        _linesperslide=[[NSMutableArray alloc] init];
        _currentSlide=0;
        blank=false;
    }
    return self;
}

- (id)initBlankSet
{
    self=[self initEmptySet];
    if(self)
    {
        blank=true;
    }
    return self;
}

- (id)initWithCoder:(NSCoder *)aDecoder
{
    self=[super init];
    if(self)
    {
        _setId=[aDecoder decodeObjectForKey:@"setId"];
        _title=[aDecoder decodeObjectForKey:@"title"];
        _byline=[aDecoder decodeObjectForKey:@"byline"];
        _copyright=[aDecoder decodeObjectForKey:@"copyright"];
        _texts=[aDecoder decodeObjectForKey:@"texts"];
        _order=[aDecoder decodeObjectForKey:@"order"];
        _chorus=[aDecoder decodeIntForKey:@"chorus"];
        _linesperslide=[aDecoder decodeObjectForKey:@"linesPerSlide"];
        _currentSlide=0;
        blank=false;
    }
    return self;
}

- (void)encodeWithCoder:(NSCoder *)aCoder
{
    [aCoder encodeObject:_setId forKey:@"setId"];
    [aCoder encodeObject:_title forKey:@"title"];
    [aCoder encodeObject:_byline forKey:@"byline"];
    [aCoder encodeObject:_copyright forKey:@"copyright"];
    [aCoder encodeObject:_texts forKey:@"texts"];
    [aCoder encodeObject:_order forKey:@"order"];
    [aCoder encodeInt:_chorus forKey:@"chorus"];
    [aCoder encodeObject:_linesperslide forKey:@"linesPerSlide"];
}

- (Slide*)getCurrentSlide
{
    Slide* ret=[[Slide alloc] init];
    ret.endOfShow=FALSE;
    ret.blank=blank;
    if(!blank)
    {
        if(_currentSlide==0&&_currentSubSlide==0)
        {
            ret.title=_title;
            ret.byline=_byline;
            ret.copyright=_copyright;
        }
        else
        {
            ret.title=[NSString string];
            ret.byline=[NSString string];
            ret.copyright=[NSString string];
        }
        NSMutableString* textToDisplay=[NSMutableString string];
        //ret.text=[texts objectAtIndex:[[order objectAtIndex:_currentSlide] intValue]];
        NSArray* textLines=[[_texts objectAtIndex:[[_order objectAtIndex:_currentSlide] intValue]] componentsSeparatedByCharactersInSet:[NSCharacterSet newlineCharacterSet]];
        unsigned long startLine=[[_linesperslide objectAtIndex:[[_order objectAtIndex:_currentSlide] intValue]] intValue]*_currentSubSlide;
        unsigned long endLine=startLine+[[_linesperslide objectAtIndex:[[_order objectAtIndex:_currentSlide] intValue]] intValue];
        unsigned long count=0;
        for(NSString* line in textLines)
        {
            if(count>=startLine&&count<endLine)
            {
                [textToDisplay appendString:line];
                [textToDisplay appendString:@"\n"];
            }
            count++;
        }
        ret.text=textToDisplay;
        if(_currentSlide>=[_order count]-1&&_currentSubSlide>=[self getSubSlideCount:[[_order objectAtIndex:_currentSlide] intValue]]-1)
        {
            ret.endOfSet=TRUE;
        }
        else
        {
            ret.endOfSet=FALSE;
        }
    }
    return ret;
}

- (BOOL)advanceSlide
{
    int maxSubSlide=[self getSubSlideCount:[[_order objectAtIndex:_currentSlide] intValue]]-1;
    if(_currentSlide>=[_order count]-1&&_currentSubSlide>=maxSubSlide)
    {
        return FALSE;
    }
    if(_currentSubSlide<maxSubSlide)
    {
        _currentSubSlide++;
    }
    else
    {
        _currentSlide++;
        _currentSubSlide=0;
    }
    return TRUE;
}

- (BOOL)unadvanceSlide
{
    if(_currentSlide<=0&&_currentSubSlide<=0)
    {
        return FALSE;
    }
    if(_currentSubSlide>0)
    {
        _currentSubSlide--;
    }
    else
    {
        _currentSlide--;
        _currentSubSlide=[self getSubSlideCount:[[_order objectAtIndex:_currentSlide] intValue]]-1;
    }
    return TRUE;
}

- (int)getSlideCount
{
    int count=0;
    for(int x=0;x<[_order count];x++)
    {
        count+=[self getSubSlideCount:[[_order objectAtIndex:x] intValue]];
    }
    return count;
}

- (int)getSubSlideCount:(int)text
{
    if(text<0||text>[_texts count]-1)
    {
        return 0;
    }
    int count=0;
    unsigned long stringLength = [[_texts objectAtIndex:text] length];
    for (unsigned long index = 0; index < stringLength; count++)
    {
        index = NSMaxRange([[_texts objectAtIndex:text] lineRangeForRange:NSMakeRange(index, 0)]);
    }
    count=(int)ceil(((float)count)/[[_linesperslide objectAtIndex:text] intValue]);
    return count;
}

- (void)goToBeginning
{
    _currentSlide=0;
    _currentSubSlide=0;
}

- (void)goToEnd
{
    _currentSlide=[_order count]-1;
    _currentSubSlide=[self getSubSlideCount:[[_order objectAtIndex:_currentSlide] intValue]]-1;
}

+ (NSString*)generateNewSetId
{
    return [[NSProcessInfo processInfo] globallyUniqueString];
}

@end
