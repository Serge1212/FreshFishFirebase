// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.


//#region custom function
function ClearSearch() {
    $('.Search-input').val('');
}
//#endregion
$(document).ready(function () {

    //#region Sub-menu

    $('.submenu-button').on('click', function () {
        if ($('.Container-submenu').is(':visible')) {
            $('.Container-submenu').fadeOut(350, function () {
                $('.Container-submenu').animate({
                    'display': 'none'
                }, 50);
            });
        }
    });
    $('.menu-button').on('click', function () {
        if ($('.Container-submenu').is(':visible')) {
            $('.Container-submenu').fadeOut(350, function () {
                $('.Container-submenu').animate({
                    'display': 'none'
                }, 50);
            });
        }
        else if ($('.menu-item-dropdown-block').is(':visible')) {
            $('.menu-item-dropdown-block').slideUp(400, function () {
                $('.menu-item-dropdown-block').animate({
                    'display': 'none'
                }, 50);
            });
            $('.Container-submenu').animate({
                'display': 'block'
            }, 50, function () {
                $('.Container-submenu').fadeIn(400);
            });
            ClearSearch();
        }

        else {
            $('.drop-down-im-pop-up-menu').slideUp(50, function () {
                $('.menu-item-dropdown-block').animate({
                    'display': 'none'
                }, 50);
                $('.Container-submenu').animate({
                    'height': '340px',
                }, 50);
            });
            $('.Container-submenu').animate({
                'display': 'block'
            }, 50, function () {
                $('.Container-submenu').fadeIn(400);
            });
            ClearSearch();
        };
    });
    //#endregion

    //#region Dropduwn sub-menu
    $('.dropdown-items').on('click', function () {
        if ($('.menu-item-dropdown-block').is(':visible')) {
            $('.menu-item-dropdown-block').slideUp(350, function () {
                $('.menu-item-dropdown-block').animate({
                    'display': 'none'
                }, 50);
            });

        }
        else if ($('.Container-submenu').is(':visible')) {
            $('.Container-submenu').fadeOut(400, function () {
                $('.Container-submenu').animate({
                    'display': 'none'
                }, 50);
            });
            $('.menu-item-dropdown-block').animate({
                'display': 'block'
            }, 50, function () {
                $('.menu-item-dropdown-block').slideDown(300);
            });
        }
        else {
            $('.menu-item-dropdown-block').animate({
                'display': 'block'
            }, 50, function () {
                $('.menu-item-dropdown-block').slideDown(300);
            });
        };
    });
    //#endregion

    //#region dropdown pop-up menu



    $('.dropdown-pop-up-menu').on('click', function () {
        if ($('.drop-down-im-pop-up-menu').is(':visible')) {
            $('.Container-submenu').animate({
                'height': '340px',
            }, 350, function () {
                $('.Container-submenu').slideDown(350);
            });
            $('.drop-down-im-pop-up-menu').slideUp(350, function () {
                $('.menu-item-dropdown-block').animate({
                    'display': 'none'
                }, 350);

            })
        }
        else {
            $('.Container-submenu').animate({
                'height': '430px',
            }, 350, function () {
                $('.Container-submenu').slideDown(350);
            });
            $('.drop-down-im-pop-up-menu').animate({
                'display': 'block',
            }, 0, function () {
                $('.drop-down-im-pop-up-menu').slideDown(350);
            });
        };
    });
    //#endregion 

    $('.search_button').click(function () {
        $('.Container-submenu').animate({
            'display': 'block'
        }, 50, function () {
            $('.Container-submenu').fadeIn(400);
        });
    })

});

//#region Pop-up menu
$(".Container-submenu, .main-menu").click(function (event) {
    event.stopPropagation();
})
$(document).click(function () {
    if ($(".Container-submenu").is(":visible")) {
        $(".Container-submenu").fadeOut(400);
    }
});
//#endregion