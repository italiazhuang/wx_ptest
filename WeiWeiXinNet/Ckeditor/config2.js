/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-cn';

    config.fullPage = false; //允许包含html标签

    // config.uiColor = '#AADC6E';
    config.filebrowserUploadUrl = "../weiweiupdata.ashx";


    config.toolbar = 'TJ';
    config.toolbar_TJ =
    [
        ['NewPage', 'Preview'],
        ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Scayt'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
        '/',
        ['Styles', 'Format'],
        ['Bold', 'Italic', 'Strike'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
        ['Link', 'Unlink', 'Anchor'],
        ['Maximize', '-', 'About']
    ];

//   // config.allowedContent = false;

//    config.startupMode = 'source';
//     

//    config.EnterMode = '';     // p | div | br
//    config.ShiftEnterMode = 'br'; // p | div | br
};
