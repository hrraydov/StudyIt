$(document).ready(

            function () {
                $("#groupSelect").on("change", function () {

                    var selected = $("#groupSelect option:selected");

                    $.ajax({
                        type: "GET",
                        url: "/api/Categories/?groupId=" + selected.attr("value"),
                        success: function (data) {

                            var html = '<option data-id="none">Избери категория</option>';

                            for (var i = 0; i < data.length; i++) {
                                html += '<option value="' + data[i].Id + '">';
                                html += data[i].Name;
                                html += '</option>';
                            }

                            $('#categorySelect').html(html);

                            $("[name=SubcategoryId]").html('<option data-id="none"Избери подкатегория</option>');

                        },
                    });

                });

                $("#categorySelect").on("change", function () {

                    var selected = $("#categorySelect option:selected");

                    $.ajax({
                        type: "GET",
                        url: "/api/Subcategories/?categoryId=" + selected.attr("value"),
                        success: function (data) {

                            var html = '<option data-id="none">Избери подкатегория</option>';

                            for (var i = 0; i < data.length; i++) {
                                html += '<option value="' + data[i].Id + '">';
                                html += data[i].Name;
                                html += '</option>';
                            }

                            $('[name=SubcategoryId]').html(html);

                        },
                    });

                });

            }
        );