//
//  IntegerFormatter.m
//  WordSlide
//
//  Created by Jonathan Ray on 9/3/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "IntegerFormatter.h"

@implementation IntegerFormatter

- (BOOL)isPartialStringValid:(NSString *__autoreleasing *)partialStringPtr proposedSelectedRange:(NSRangePointer)proposedSelRangePtr originalString:(NSString *)origString originalSelectedRange:(NSRange)origSelRange errorDescription:(NSString *__autoreleasing *)error
{
    if([*partialStringPtr length]<=2)
    {
        for(int x=0;x<[*partialStringPtr length];x++)
        {
            if(![[NSCharacterSet decimalDigitCharacterSet] characterIsMember:[*partialStringPtr characterAtIndex:x]])
            {
                return NO;
            }
        }
        return YES;
    }
    return NO;
}

@end
