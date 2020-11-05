
//#region custom function
function ClearSearch() {
    $('.Search-input').val('');
}
const menuButton = document.querySelector('.Mobile_menu_button');
const menuO = document.querySelector('.Mobile_menu');
let menuOpen = false;
const drop_down_in_mobile_menu = document.querySelector('.drop_down_in_mobile_menu');
let DropDowmMenuOpen = false;
$('.dropdowm_mobile_menu').click(function () {
    if (!DropDowmMenuOpen) {
        $('.dropdown-after').toggleClass('expanded');
        $('.drop_down_in_mobile_menu').animate({
            'display': 'block'
        }, 5, function () {
            $('.drop_down_in_mobile_menu').slideDown(400);
        });
        DropDowmMenuOpen = true;
    }
    else {
        $('.dropdown-after').removeClass('expanded');
        $('.drop_down_in_mobile_menu').animate({
            'display': 'none'
        }, 5, function () {
            $('.drop_down_in_mobile_menu').slideUp(400);
        });
        DropDowmMenuOpen = false;
    }
});
menuButton.addEventListener('click', () => {
    if (!menuOpen) {
        $('.dropdown-after').removeClass('expanded');
        $('.drop_down_in_mobile_menu').animate({
            'display': 'none'
        }, 5, function () {
            $('.drop_down_in_mobile_menu').slideUp(10);
        });
        menuButton.classList.add('Open_menu');
        menuO.classList.add('Open_menu');
        // menuO.classList.remove('Close_menu');
        menuOpen = true;
    }
    else {
        // menuO.classList.add('Close_menu');
        menuButton.classList.remove('Open_menu');
        menuO.classList.remove('Open_menu');
        menuOpen = false;
    }
})
//Open menu command


//#endregion
$(document).ready(function () {
    $(window).resize(function () {
        if ($(window).height() > 500) {
            menuButton.classList.remove('Open_menu');
            menuO.classList.remove('Open_menu');
        }
        if ($(window).height() < 500 || $(window).width() < 500) {
            $('.Container-submenu').hide()
        }
    });
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
            $('.dropdown-after').removeClass('expanded');
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
            $('.dropdown-after').removeClass('expanded');
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
            $('.dropdown-after').removeClass('expanded');
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
            $('.dropdown-after').toggleClass('expanded');
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