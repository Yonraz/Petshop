import $ from "jquery"
    $(document).ready(function () {
        $("#editAnimalForm").validate({
            rules: {
                Name: {
                    required: true,
                },
                Age: {
                    required: true,
                    digits: true,
                },
                Category: {
                    required: true,
                },
                PictureName: {
                    required: true,
                    extension: "jpg|jpeg|png|gif",
                },
                Description: {
                    required: true,
                },
            },
            messages: {
                Name: {
                    required: "Please enter a name",
                },
                Age: {
                    required: "Please enter an age",
                    digits: "Please enter a valid age (digits only)",
                },
                Category: {
                    required: "Please enter a category",
                },
                PictureName: {
                    required: "Please select an image file",
                    extension: "Please upload a valid image file (jpg, jpeg, png, gif)",
                },
                Description: {
                    required: "Please enter a description",
                },
            },
            errorElement: "span",
            errorClass: "text-danger",
        });
        $("#editAnimalForm").submit(function (event) {
            event.preventDefault();
            debugger;
            if ($(this).valid()) {
                var animal = {
                    AnimalId: $("#animalId").val(),
                    Name: $("#name").val(),
                    Age: $("#age").val(),
                    Category: $("#category").val(),
                    PictureName: $("#pictureName").val(),
                    Description: $("#description").val(),
                };

                $.ajax({
                    url: "/Animal/OnAnimalEdit",
                    type: "POST",
                    data: { animal: animal },
                    success: function (response) {
                        if (response) {
                            window.location.href = "/Animal/Index";
                        }
                    },
                });
            }
        });
    })
