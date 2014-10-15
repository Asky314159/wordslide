//
//  AppDelegate.m
//  WordSlide
//
//  Created by Jonathan Ray on 6/28/13.
//  Copyright (c) 2013 Jonathan Ray. All rights reserved.
//

#import "AppDelegate.h"

@implementation AppDelegate

- (void)applicationDidFinishLaunching:(NSNotification *)aNotification
{
    // Insert code here to initialize your application
    _options=[[WordSlideOptions alloc] initWithDefaults];
    engine=[[WordslideEngine alloc] initWithStuff];
    [_slidePoolTable setDataSource:engine.slidePoolDelegate];
    [_slidePoolTable setDelegate:engine.slidePoolDelegate];
    [_slideShowTable setDataSource:engine.slideShowDelegate];
    [_slideShowTable setDelegate:engine.slideShowDelegate];
    editorEngine=[[SlideEditorEngine alloc] initEmpty:self];
    [_editorSlidePoolTable setDataSource:editorEngine.slidePoolDelegate];
    [_editorSlidePoolTable setDelegate:editorEngine.slidePoolDelegate];
    [_editorSlideSetTable setDataSource:editorEngine.slideSetDelegate];
    [_editorSlideSetTable setDelegate:editorEngine.slideSetDelegate];
}

- (BOOL)applicationShouldTerminateAfterLastWindowClosed:(NSApplication *)app
{
    return YES;
}

- (IBAction)startButtonPressed:(NSButton *)sender {
    if([engine beginShow])
    {
        [_slideshowView enterFullScreenMode:[NSScreen mainScreen] withOptions:[NSDictionary dictionaryWithObjectsAndKeys:[NSNumber numberWithBool:true], NSFullScreenModeAllScreens, NSApplicationPresentationDefault, NSFullScreenModeApplicationPresentationOptions, nil]];
        CGDisplayHideCursor(kCGDirectMainDisplay);
        //[_debugController makeKeyAndOrderFront:NSApp];
        //debugWindow=[[NSWindow alloc] initWithContentRect:NSMakeRect(0, 0, 1024, 768) styleMask:NSBorderlessWindowMask backing:NSBackingStoreBuffered defer:NO];
        //debugWindow.contentView=_slideshowView;
        //[debugWindow makeKeyAndOrderFront:NSApp];
    }
}

- (void)exitSlideShow
{
    [_slideshowView exitFullScreenModeWithOptions:[NSDictionary dictionaryWithObjectsAndKeys:[NSNumber numberWithBool:true], NSFullScreenModeAllScreens, NSApplicationPresentationDefault, NSFullScreenModeApplicationPresentationOptions, nil]];
    CGDisplayShowCursor(kCGDirectMainDisplay);
}

- (IBAction)addButtonPressed:(NSButton *)sender {
    if(_slidePoolTable.selectedRow!=-1)
    {
        [engine addRowToShow:_slidePoolTable.selectedRow];
        [_slideShowTable reloadData];
        [_slideShowTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[engine.slideShowDelegate getListLength]-1] byExtendingSelection:NO];
    }
}

- (IBAction)removeButtonPressed:(NSButton *)sender {
    if(_slideShowTable.selectedRow!=-1)
    {
        NSInteger selectedRow=_slideShowTable.selectedRow;
        [engine removeRowFromShow:selectedRow];
        [_slideShowTable reloadData];
        if([engine.slideShowDelegate getListLength]-1<selectedRow)
        {
            [_slideShowTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[engine.slideShowDelegate getListLength]-1] byExtendingSelection:NO];
        }
        else
        {
            [_slideShowTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow] byExtendingSelection:NO];
        }
    }
}

- (IBAction)reorderUpButtonPressed:(NSButton *)sender {
    if(_slideShowTable.selectedRow>0&&_slideShowTable.selectedRow<[engine.slideShowDelegate getListLength])
    {
        NSInteger selectedRow=_slideShowTable.selectedRow;
        [engine reorderShowRowUp:selectedRow];
        [_slideShowTable reloadData];
        [_slideShowTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow-1] byExtendingSelection:NO];
    }
}

- (IBAction)reorderDownButtonPressed:(NSButton *)sender {
    if(_slideShowTable.selectedRow>=0&&_slideShowTable.selectedRow<[engine.slideShowDelegate getListLength]-1)
    {
        NSInteger selectedRow=_slideShowTable.selectedRow;
        [engine reorderShowRowDown:selectedRow];
        [_slideShowTable reloadData];
        [_slideShowTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow+1] byExtendingSelection:NO];
    }
}

- (IBAction)newButtonPressed:(id)sender {
    [self setEditorFieldsForId:[NSString string]];
    [NSApp beginSheet:_editorView modalForWindow:_window modalDelegate:self didEndSelector:@selector(didEndSheet:returnCode:contextInfo:) contextInfo:nil];
}

- (IBAction)editButtonPressed:(id)sender {
    if(_slidePoolTable.selectedRow!=-1)
    {
        [self setEditorFieldsForId:[engine getPoolId:_slidePoolTable.selectedRow]];
        [NSApp beginSheet:_editorView modalForWindow:_window modalDelegate:self didEndSelector:@selector(didEndSheet:returnCode:contextInfo:) contextInfo:nil];
    }
}

- (IBAction)deleteButtonPressed:(id)sender {
    if(_slidePoolTable.selectedRow!=-1)
    {
        NSAlert* confirmDialog=[[NSAlert alloc] init];
        confirmDialog.messageText=[NSString stringWithFormat:@"Really delete library item '%@'?", [engine getSlideSetForId:[engine getPoolId:_slidePoolTable.selectedRow]].title];
        confirmDialog.informativeText=@"This operation cannot be undone.";
        confirmDialog.alertStyle=NSWarningAlertStyle;
        [confirmDialog addButtonWithTitle:@"Yes"];
        [confirmDialog addButtonWithTitle:@"No"];
        [confirmDialog beginSheetModalForWindow:_window completionHandler:^(NSModalResponse returnCode){
            if(returnCode==NSAlertFirstButtonReturn)
            {
                [engine deleteSlideSet:[engine getPoolId:_slidePoolTable.selectedRow]];
                [_slidePoolTable reloadData];
                [_slideShowTable reloadData];
            }
        }];
    }
}

- (void)setEditorFieldsForId:(NSString*)setId
{
    if(setId.length==0)
    {
        [editorEngine openNewSetForEdit];
    }
    else
    {
        [editorEngine openSetForEdit:[engine getSlideSetForId:setId]];
    }
    
    suppressSave=YES;
    _editorTitleField.stringValue=editorEngine.slideTitle;
    _editorBylineField.stringValue=editorEngine.slideByline;
    _editorCopyrightField.stringValue=editorEngine.slideCopyright;
    [_editorSlidePoolTable reloadData];
    [_editorSlideSetTable reloadData];
    if([editorEngine.slidePoolDelegate getListLength]>0)
    {
        [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:0] byExtendingSelection:NO];
    }
    else
    {
        _editorVerseField.string=[NSString string];
        _editorLpsField.integerValue=4;
        _editorLpsSelector.integerValue=4;
    }
    suppressSave=NO;
    [self refreshButtonState];
}

- (IBAction)insertBlankButtonPressed:(id)sender {
    [engine addBlankSlideToShow];
    [_slideShowTable reloadData];
}

- (IBAction)clearButtonPressed:(id)sender {
    [engine clearShow];
    [_slideShowTable reloadData];
}

- (IBAction)editorSaveButtonPressed:(id)sender {
    [NSApp endSheet:_editorView returnCode:0];
}

- (IBAction)editorDiscardButtonPressed:(id)sender {
    [NSApp endSheet:_editorView returnCode:1];
}

- (IBAction)debugForwardButtonPressed:(id)sender {
    [_slideshowView keyDown:[NSEvent keyEventWithType:NSKeyDown location:NSMakePoint(0, 0) modifierFlags:0 timestamp:0 windowNumber:0 context:nil characters:@"" charactersIgnoringModifiers:@"" isARepeat:NO keyCode:124]];
}

- (IBAction)debugBackButtonPressed:(id)sender {
    [_slideshowView keyDown:[NSEvent keyEventWithType:NSKeyDown location:NSMakePoint(0, 0) modifierFlags:0 timestamp:0 windowNumber:0 context:nil characters:@"" charactersIgnoringModifiers:@"" isARepeat:NO keyCode:123]];
}

- (void)didEndSheet:(NSWindow *)sheet returnCode:(NSInteger)returnCode contextInfo:(void *)contextInfo
{
    if(returnCode==0)
    {
        [self saveCurrentSlide];
        SlideSet* savedSet=[editorEngine getSlideSet];
        [engine addSlideSet:savedSet];
        [_slidePoolTable reloadData];
        [_slideShowTable reloadData];
    }
    [sheet orderOut:self];
}

- (void)advanceSlide
{
    [engine advanceSlide];
}

- (void)unadvanceSlide
{
    [engine unadvanceSlide];
}

- (Slide*)getCurrentSlide
{
    return [engine getCurrentSlide];
}

- (IBAction)editorLpsSelectorChanged:(id)sender {
    [_editorLpsField setIntegerValue:[_editorLpsSelector integerValue]];
}

- (IBAction)editorLpsFieldChanged:(id)sender {
    [_editorLpsSelector setIntegerValue:[_editorLpsField integerValue]];
}

- (IBAction)editorCopyrightButtonPressed:(id)sender {
    _editorCopyrightField.stringValue=[[_editorCopyrightField stringValue] stringByAppendingString:@"©"];
    editorEngine.slideCopyright=[NSString stringWithString:_editorCopyrightField.stringValue];
}

- (IBAction)editorAddButtonPressed:(id)sender {
    if(_editorSlidePoolTable.selectedRow!=-1)
    {
        [editorEngine addSlideToOrder:_editorSlidePoolTable.selectedRow];
        [_editorSlideSetTable reloadData];
        [self refreshButtonState];
        [_editorSlideSetTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[editorEngine.slideSetDelegate getListLength]-1] byExtendingSelection:NO];
    }
}

- (IBAction)editorRemoveButtonPressed:(id)sender {
    if(_editorSlideSetTable.selectedRow!=-1)
    {
        NSInteger selectedRow=_editorSlideSetTable.selectedRow;
        [editorEngine removeSlideFromOrder:selectedRow];
        [_editorSlideSetTable reloadData];
        [self refreshButtonState];
        if([editorEngine.slideSetDelegate getListLength]-1<selectedRow)
        {
            [_editorSlideSetTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[editorEngine.slideSetDelegate getListLength]-1] byExtendingSelection:NO];
        }
        else
        {
            [_editorSlideSetTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow] byExtendingSelection:NO];
        }
    }
}

- (IBAction)editorReorderUpButtonPressed:(id)sender {
    if(_editorSlideSetTable.selectedRow>0&&_editorSlideSetTable.selectedRow<[editorEngine.slideSetDelegate getListLength])
    {
        NSInteger selectedRow=_editorSlideSetTable.selectedRow;
        [editorEngine reorderSlideUp:selectedRow];
        [_editorSlideSetTable reloadData];
        [_editorSlideSetTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow-1] byExtendingSelection:NO];
    }
}

- (IBAction)editorReorderDownButtonPressed:(id)sender {
    if(_editorSlideSetTable.selectedRow>=0&&_editorSlideSetTable.selectedRow<[editorEngine.slideSetDelegate getListLength]-1)
    {
        NSInteger selectedRow=_editorSlideSetTable.selectedRow;
        [editorEngine reorderSlideDown:selectedRow];
        [_editorSlideSetTable reloadData];
        [_editorSlideSetTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow+1] byExtendingSelection:NO];
    }
}

- (IBAction)editorChorusButtonPressed:(id)sender {
    if(_editorSlidePoolTable.selectedRow!=-1)
    {
        suppressSave=YES;
        [self saveCurrentSlide];
        [editorEngine setChorus:_editorSlidePoolTable.selectedRow];
        [_editorSlidePoolTable reloadData];
        [_editorSlideSetTable reloadData];
        [self refreshButtonState];
        NSInteger newIndex=editorEngine.slideChorus;
        [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:newIndex] byExtendingSelection:NO];
        editorEngine.selectedIndex=newIndex;
    }
}

- (IBAction)editorNewButtonPressed:(id)sender {
    [editorEngine newSlide];
    [_editorSlidePoolTable reloadData];
    [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[editorEngine.slidePoolDelegate getListLength]-1] byExtendingSelection:NO];
}

- (IBAction)editorDeleteButtonPressed:(id)sender {
    if(_editorSlidePoolTable.selectedRow!=-1)
    {
        NSInteger selectedRow=_editorSlidePoolTable.selectedRow;
        [editorEngine deleteSlide:selectedRow];
        [_editorSlidePoolTable reloadData];
        [_editorSlideSetTable reloadData];
        [self refreshButtonState];
        if([editorEngine.slidePoolDelegate getListLength]==0)
        {
            _editorVerseField.string=[NSString string];
            [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:-1] byExtendingSelection:NO];
        }
        else if([editorEngine.slidePoolDelegate getListLength]-1<selectedRow)
        {
            suppressSave=YES;
            [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:[editorEngine.slidePoolDelegate getListLength]-1] byExtendingSelection:NO];
        }
        else
        {
            suppressSave=YES;
            [_editorSlidePoolTable selectRowIndexes:[NSIndexSet indexSetWithIndex:selectedRow] byExtendingSelection:NO];
        }
    }
}

- (IBAction)editorSlideTitleChanged:(id)sender {
    editorEngine.slideTitle=[NSString stringWithString:_editorTitleField.stringValue];
    [self refreshButtonState];
}

- (IBAction)editorSlideBylineChanged:(id)sender {
    editorEngine.slideByline=[NSString stringWithString:_editorBylineField.stringValue];
}

- (IBAction)editorSlideCopyrightChanged:(id)sender {
    editorEngine.slideCopyright=[NSString stringWithString:_editorCopyrightField.stringValue];
}

- (void)refreshButtonState
{
    if([editorEngine.slidePoolDelegate getListLength]>0&&_editorSlidePoolTable.selectedRow!=-1)
    {
        [_editorVerseField setEditable:YES];
        [_editorChorusButton setEnabled:editorEngine.slideChorus==-1];
    }
    else
    {
        [_editorVerseField setEditable:NO];
        [_editorChorusButton setEnabled:NO];
    }
    [_editorSaveButton setEnabled:editorEngine.slideTitle.length>0&&[editorEngine.slideSetDelegate getListLength]>0];
}

- (void)editorPoolSelectedChanged {
    [self refreshButtonState];
    if(!suppressSave)
    {
        [self saveCurrentSlide];
    }
    else
    {
        suppressSave=NO;
    }
    if(_editorSlidePoolTable.selectedRow!=-1)
    {
        _editorVerseField.string=[editorEngine getTextForIndex:_editorSlidePoolTable.selectedRow];
        _editorLpsSelector.integerValue=[editorEngine getLpsForIndex:_editorSlidePoolTable.selectedRow];
        _editorLpsField.integerValue=_editorLpsSelector.integerValue;
    }
    else
    {
        _editorVerseField.string=[NSString string];
        _editorLpsSelector.integerValue=4;
        _editorLpsField.integerValue=4;
    }
}

- (void)saveCurrentSlide
{
    if(editorEngine.selectedIndex!=-1)
    {
        [editorEngine setTextForSelectedSlide:_editorVerseField.string];
        [editorEngine setLpsForSelectedSlide:_editorLpsSelector.integerValue];
    }
    editorEngine.selectedIndex=_editorSlidePoolTable.selectedRow;
}
@end
