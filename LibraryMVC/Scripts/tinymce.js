tinymce.init({
    // General options
    selector: "textarea",
    height: 500,
    width: 700,
    theme: "modern",    
    font_formats: 'Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n',
    fontsize_formats: '8pt 10pt 12pt 14pt 18pt 24pt 36pt',
    browser_spellcheck: true,
    force_br_newlines: true,
    force_p_newlines: false,
    forced_root_block: '',
    convert_urls: false,    
    resize: 'both',
    plugins: [
   'advlist autolink lists link image charmap print preview hr anchor pagebreak',
   'searchreplace wordcount visualblocks visualchars code fullscreen',
   'insertdatetime media nonbreaking save table contextmenu directionality',
   'emoticons template paste textcolor colorpicker textpattern imagetools'
    ],
    toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    toolbar2: 'print preview media | forecolor backcolor emoticons | fontsizeselect',
    image_advtab: true,
    content_css: [
      '/content/mycontent.css'      
    ]
});

$.validator.setDefaults({ ignore: '' });