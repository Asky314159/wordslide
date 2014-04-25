//
//  SlideshowView.h
//  WordSlide
//
//  Created by Jonathan Ray on 6/28/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "AppDelegate.h"

@interface SlideshowView : NSView
{
    int lastKeyPress;
    bool showLastKey;
    bool blankScreen;
}

@property (assign) IBOutlet AppDelegate *appDelegate;

@end
