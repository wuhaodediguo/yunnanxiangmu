/**
* @license Copyright (c) 2003-2014, CKSource - Frederico Knabben. All rights reserved.
* For licensing, see LICENSE.md or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For complete reference see:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config

    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'tools' },
		{ name: 'others' },
		{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
		{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'links' },
		{ name: 'insert' }
	];

    //remove auto add <br> and <p>
    config.enterMode = CKEDITOR.ENTER_BR;
    config.shiftEnterMode = CKEDITOR.ENTER_P;
    config.extraPlugins = "album";
};
