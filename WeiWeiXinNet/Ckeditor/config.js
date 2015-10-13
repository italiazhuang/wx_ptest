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

//   // config.allowedContent = false;

//    config.startupMode = 'source';
//     

//    config.EnterMode = '';     // p | div | br
    //    config.ShiftEnterMode = 'br'; // p | div | br




    // Toolbar configuration generated automatically by the editor based on config.toolbarGroups.
    config.toolbar = [
	{ name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-',  'Preview', '-', 'Templates'] },
	{ name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent',  'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
	{ name: 'links', items: ['Link', 'Unlink'] },
	{ name: 'insert', items: ['Image',  'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak' ] },
	{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
	{ name: 'colors', items: ['TextColor', 'BGColor'] } 
	 
	 
];

    // Toolbar groups configuration.
    config.toolbarGroups = [
	{ name: 'document', groups: ['mode', 'document', 'doctools'] },
	{ name: 'clipboard', groups: ['clipboard', 'undo'] }, 
	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
	{ name: 'links' },
	{ name: 'insert' },
	{ name: 'styles' },
	{ name: 'colors' } 
	 
	 
];







};
