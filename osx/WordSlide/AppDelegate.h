//
//  AppDelegate.h
//  WordSlide
//
//  Created by Jonathan Ray on 6/28/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "WordslideEngine.h"
#import "WordSlideOptions.h"
#import "Slide.h"
#import "SlideEditorEngine.h"

@interface AppDelegate : NSObject <NSApplicationDelegate>
{
    WordslideEngine *engine;
    NSWindow* debugWindow;
    SlideEditorEngine* editorEngine;
    BOOL suppressSave;
}

@property (assign) IBOutlet NSWindow *window;
- (IBAction)startButtonPressed:(NSButton *)sender;
@property (weak) IBOutlet NSView *slideshowView;
@property (weak) IBOutlet NSTableView *slidePoolTable;
@property (weak) IBOutlet NSTableView *slideShowTable;
- (IBAction)addButtonPressed:(NSButton *)sender;
- (IBAction)removeButtonPressed:(NSButton *)sender;
- (IBAction)reorderUpButtonPressed:(NSButton *)sender;
- (IBAction)reorderDownButtonPressed:(NSButton *)sender;
- (IBAction)newButtonPressed:(id)sender;
- (IBAction)editButtonPressed:(id)sender;
- (IBAction)insertBlankButtonPressed:(id)sender;
- (IBAction)clearButtonPressed:(id)sender;
@property (unsafe_unretained) IBOutlet NSPanel *editorView;
@property (unsafe_unretained) IBOutlet NSWindow *debugController;
- (IBAction)editorSaveButtonPressed:(id)sender;
- (IBAction)editorDiscardButtonPressed:(id)sender;
- (IBAction)debugForwardButtonPressed:(id)sender;
- (IBAction)debugBackButtonPressed:(id)sender;
- (void)didEndSheet:(NSWindow *)sheet returnCode:(NSInteger)returnCode contextInfo:(void *)contextInfo;
@property (readonly) WordSlideOptions* options;
- (void)exitSlideShow;
- (void)advanceSlide;
- (void)unadvanceSlide;
- (Slide*)getCurrentSlide;
@property (weak) IBOutlet NSStepper *editorLpsSelector;
- (IBAction)editorLpsSelectorChanged:(id)sender;
@property (weak) IBOutlet NSTextField *editorLpsField;
- (IBAction)editorLpsFieldChanged:(id)sender;
@property (weak) IBOutlet NSTextField *editorTitleField;
@property (weak) IBOutlet NSTextField *editorBylineField;
@property (weak) IBOutlet NSTextField *editorCopyrightField;
- (IBAction)editorCopyrightButtonPressed:(id)sender;
@property (unsafe_unretained) IBOutlet NSTextView *editorVerseField;
@property (weak) IBOutlet NSTableView *editorSlidePoolTable;
@property (weak) IBOutlet NSTableView *editorSlideSetTable;
- (IBAction)editorAddButtonPressed:(id)sender;
- (IBAction)editorRemoveButtonPressed:(id)sender;
- (IBAction)editorReorderUpButtonPressed:(id)sender;
- (IBAction)editorReorderDownButtonPressed:(id)sender;
- (IBAction)editorChorusButtonPressed:(id)sender;
@property (weak) IBOutlet NSButton *editorChorusButton;
- (IBAction)editorNewButtonPressed:(id)sender;
- (IBAction)editorDeleteButtonPressed:(id)sender;
- (IBAction)editorSlideTitleChanged:(id)sender;
- (IBAction)editorSlideBylineChanged:(id)sender;
- (IBAction)editorSlideCopyrightChanged:(id)sender;
@property (weak) IBOutlet NSButton *editorSaveButton;
@property (readwrite) int editorLpsValue;
- (void)editorPoolSelectedChanged;

@end
