//
//  SlideshowView.m
//  WordSlide
//
//  Created by Jonathan Ray on 6/28/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "SlideshowView.h"

@implementation SlideshowView

- (id)initWithFrame:(NSRect)frame
{
    self = [super initWithFrame:frame];
    if (self) {
        lastKeyPress=0;
        showLastKey=FALSE;
        blankScreen=FALSE;
    }
    
    return self;
}

- (void)drawRect:(NSRect)dirtyRect
{
    // Drawing code here.
    [[NSColor blackColor] setFill];
    NSRectFill([self bounds]);
    if(showLastKey)
    {
    NSString *keyString=[NSString stringWithFormat:@"%d",lastKeyPress];
    [keyString drawAtPoint:NSMakePoint(25, 25) withAttributes:[NSDictionary dictionaryWithObjectsAndKeys:[NSColor whiteColor], NSForegroundColorAttributeName, _appDelegate.options.textFont, NSFontAttributeName, nil]];
    }
    Slide* currentSlide=[_appDelegate getCurrentSlide];
    if(currentSlide!=nil&&!currentSlide.blank&&!blankScreen)
    {
        NSMutableParagraphStyle* paragraphStyle=[[NSMutableParagraphStyle alloc] init];
        paragraphStyle.alignment=NSCenterTextAlignment;
        NSDictionary* titleAttributes=[NSDictionary dictionaryWithObjectsAndKeys:[NSColor whiteColor], NSForegroundColorAttributeName, _appDelegate.options.titleFont, NSFontAttributeName, paragraphStyle, NSParagraphStyleAttributeName, nil];
        NSDictionary* textAttributes=[NSDictionary dictionaryWithObjectsAndKeys:[NSColor whiteColor], NSForegroundColorAttributeName, _appDelegate.options.textFont, NSFontAttributeName, paragraphStyle, NSParagraphStyleAttributeName, nil];
        NSDictionary* bylineAttributes=[NSDictionary dictionaryWithObjectsAndKeys:[NSColor whiteColor], NSForegroundColorAttributeName, _appDelegate.options.bylineFont, NSFontAttributeName, paragraphStyle, NSParagraphStyleAttributeName, nil];
        NSDictionary* dotAttributes=[NSDictionary dictionaryWithObjectsAndKeys:[NSColor whiteColor], NSForegroundColorAttributeName, _appDelegate.options.dotFont, NSFontAttributeName, paragraphStyle, NSParagraphStyleAttributeName, nil];
        float stringWidth=dirtyRect.size.width;
        float stringTop=dirtyRect.size.height;
        if([currentSlide.title length]!=0)
        {
            stringTop-=_appDelegate.options.titleStart;
            float titleHeight=[currentSlide.title sizeWithAttributes:titleAttributes].height;
            stringTop-=titleHeight;
            [currentSlide.title drawInRect:NSMakeRect(0, stringTop, stringWidth, titleHeight) withAttributes:titleAttributes];
            if([currentSlide.byline length]!=0)
            {
                float bylineHeight=[currentSlide.byline sizeWithAttributes:bylineAttributes].height;
                stringTop-=bylineHeight;
                [currentSlide.byline drawInRect:NSMakeRect(0, stringTop, stringWidth, bylineHeight) withAttributes:bylineAttributes];
            }
            if([currentSlide.copyright length]!=0)
            {
                float copyrightHeight=[currentSlide.copyright sizeWithAttributes:bylineAttributes].height;
                stringTop-=copyrightHeight;
                [currentSlide.copyright drawInRect:NSMakeRect(0, stringTop, stringWidth, copyrightHeight) withAttributes:bylineAttributes];
            }
            stringTop-=_appDelegate.options.titleTextSpace;
        }
        else
        {
            stringTop-=_appDelegate.options.textStart;
        }
        float textHeight=[currentSlide.text sizeWithAttributes:textAttributes].height;
        stringTop-=textHeight;
        [currentSlide.text drawInRect:NSMakeRect(0, stringTop, stringWidth, textHeight) withAttributes:textAttributes];
        if(currentSlide.endOfSet||currentSlide.endOfShow)
        {
            NSString* dotString=(currentSlide.endOfShow?_appDelegate.options.endOfShowString:_appDelegate.options.endOfSetString);
            float dotHeight=[dotString sizeWithAttributes:dotAttributes].height;
            [dotString drawInRect:NSMakeRect(0, _appDelegate.options.dotSpace, stringWidth, dotHeight) withAttributes:dotAttributes];
        }
    }
}

- (BOOL) acceptsFirstResponder
{
    return YES;
}

- (void) keyDown:(NSEvent *)theEvent
{
    lastKeyPress=[theEvent keyCode];
    switch([theEvent keyCode])
    {
        case 53:
            [_appDelegate exitSlideShow];
            break;
        case 123:
            [_appDelegate unadvanceSlide];
            [self setNeedsDisplay:YES];
            break;
        case 36:
        case 49:
        case 124:
            [_appDelegate advanceSlide];
            [self setNeedsDisplay:YES];
            break;
        case 111:
            showLastKey=!showLastKey;
            [self setNeedsDisplay:YES];
            break;
        case 11:
            blankScreen=!blankScreen;
            [self setNeedsDisplay:YES];
            break;
        default:
            if(showLastKey)
            {
                [self setNeedsDisplay:YES];
            }
            break;
    }
}

@end
