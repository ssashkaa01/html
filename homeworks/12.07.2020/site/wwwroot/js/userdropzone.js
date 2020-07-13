Dropzone.autoDiscover = false;
Dropzone.prototype.defaultOptions.dictDefaultMessage = "Перетягніть файл для завантаження суди";
Dropzone.prototype.defaultOptions.dictFallbackMessage = "Your browser does not support drag'n'drop file uploads.";
Dropzone.prototype.defaultOptions.dictFallbackText = "Please use the fallback form below to upload your files like in the olden days.";
Dropzone.prototype.defaultOptions.dictFileTooBig = "File is too big ({{filesize}}MiB). Max filesize: {{maxFilesize}}MiB.";
Dropzone.prototype.defaultOptions.dictInvalidFileType = "You can't upload files of this type.";
Dropzone.prototype.defaultOptions.dictResponseError = "Server responded with {{statusCode}} code.";
Dropzone.prototype.defaultOptions.dictCancelUpload = "Cancel upload";
Dropzone.prototype.defaultOptions.dictCancelUploadConfirmation = "Are you sure you want to cancel this upload?";
Dropzone.prototype.defaultOptions.dictRemoveFile = "Видалити файл";
Dropzone.prototype.defaultOptions.dictMaxFilesExceeded = "You can not upload any more files.";

$(".dropzone").dropzone({
    addRemoveLinks: true,
    maxFiles: 1,
    init: function () {
        //var dropzoneForm = this;
        //this function check if there is an file already uploaded
        // if yes it removes the first/last file

        this.on("addedfile", function (file) {
            if (this.files[1] != null) { //Не більше одного файла на загрузку
                this.removeFile(this.files[0]);
            }

        });

        this.on("success", function (file, response) {
            file.id = response.id;  //Зберігаємо назву файла на сервері
            $("#image").val(`${response.id}`);
            console.log("Object hello", file.id);
        });

    },
    removedfile: function (file) {
        
        var name = file.name;
        if (!clearFormControls) {  //якщо не проводиться процедура очищення інпутів
            //console.log("remove file name", file.id);
            $.ajax({
                type: 'POST',
                url: `${urlSite}api/users/removefile`,
                data: { name: file.id, request: 2 },
                sucess: function (data) {
                    console.log('success: ' + data);
                }
            });
        }
        var _ref;
        return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
    }
});