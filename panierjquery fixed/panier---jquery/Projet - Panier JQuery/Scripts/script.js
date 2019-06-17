$(document).ready(function () {
    var cartContent = []; // tableau contenu du panier
    // tableau produits
    var items = [
        {
            'id': 'rando1',
            'name': 'CH MH500 WTP H Noir ',
            'image': 'Content/img/rando1.jpg',
            'description': 'Chaussures de randonnée montagne homme MH500 imperméable Noir QUECHUA',
            'ref': '2039054',
            'category': 'randonnée',
            'price': 60,
            'quantity': 1
        },
        {
            'id': 'rando2',
            'name': 'CHAUSSURES MH100 JR BLEUES',
            'image': 'Content/img/rando2.jpg',
            'description': 'Chaussures de randonnée enfant MH100 JR bleues QUECHUA',
            'ref': '2039334',
            'category': 'randonnée',
            'price': 60,
            'quantity': 1
        },
        {
            'id': 'rando3',
            'name': 'SAC A DOS FORCLAZ 50L GRS',
            'image': 'Content/img/rando3.jpg',
            'description': 'Sac à dos Trekking forclaz 50 litres gris QUECHUA',
            'ref': '2039034',
            'category': 'randonnée',
            'price': 40, 
            'quantity': 1
        },
        {
            'id': 'rando4',
            'name': 'SAC A DOS TRAVEL500 50L F BLE ',
            'image': 'Content/img/rando4.jpg',
            'description': 'Sac à dos trekking TRAVEL500 50 litres cadenassable femme bleu FORCLAZ',
            'ref': '2038034',
            'category': 'randonnée',
            'price': 80,
            'quantity': 1
        },
        {
            'id': 'rando5',
            'name': 'Tente AIR SECONDS 8.4 F&B',
            'image': 'Content/img/rando5.jpg',
            'description': 'Tente de camping gonflable AIR SECONDS 8.4 FRESH&BLACK | 8 Personnes 4 Chambres QUECHUA',
            'ref': '2038654',
            'category': 'randonnée',
            'price': 800,
            'quantity': 1
        },
        {
            'id': 'rando6',
            'name': 'Tente ARPENAZ 4',
            'image': 'Content/img/rando6.jpg',
            'description': 'Tente de camping à arceaux ARPENAZ 4 | 4 Personnes 1 Chambre QUECHUA',
            'ref': '20376784',
            'category': 'randonnée',
            'price': 80,
            'quantity': 1
        },
        {
            'id': 'nautisme1',
            'name': 'Veste de quart OS31',
            'image': 'Content/img/nautisme1.png',
            'description': 'En 2018, Gill a ajouté la veste OS3 Coastal à sa ligne très appréciée pour la navigation au large, en s’appuyant sur les points forts du concept original et en apportant une touche élégante et moderne qui conviendra aussi bien au navigateur débutant qu’au marin confirmé.',
            'ref': '20376884',
            'category': 'nautisme',
            'price': 210,
            'quantity': 1
        },
        {
            'id': 'nautisme2',
            'name': 'Hublot ouvrant standard',
            'image': 'Content/img/nautisme2.png',
            'description': 'Hublot ouvrant standard Lewmar avec cadre extérieur en aluminium. ',
            'ref': '20376883',
            'category': 'nautisme',
            'price': 278,
            'quantity': 1
        },
        {
            'id': 'nautisme3',
            'name': 'RT-411',
            'image': 'Content/img/nautisme3.jpg',
            'description': 'La VHF RT-411 de Navicom est une VHF portable Puissance 5W',
            'ref': '22376683',
            'category': 'nautisme',
            'price': 124.99,
            'quantity': 1
        },
        {
            'id': 'nautisme4',
            'name': 'Booster batterie Lithium',
            'image': 'Content/img/nautisme4.png',
            'description': 'Booster de batterie 12V ultra compact, à batterie Lithium. Permet de redémarrer votre moteur en cas de panne si celui-ci possède une batterie 12V',
            'ref': '12376683',
            'category': 'nautisme',
            'price': 129.99,
            'quantity': 1
        },
        {
            'id': 'nautisme5',
            'name': 'Antifouling matrice dure',
            'image': 'Content/img/nautisme5.png',
            'description': 'Antifouling matrice dure particulièrement adapté aux unités rapides. Performant même dans les eaux à fortes salissures.',
            'ref': '12476683',
            'category': 'nautisme',
            'price': 29.99,
            'quantity': 1
        },
        {
            'id': 'nautisme6',
            'name': 'Projecteurs de pont LEDS',
            'image': 'Content/img/nautisme6.png',
            'description': 'Projecteurs LEDS pour installation sur pont ou barre de flèche. Lumière blanc froid, corps robustes en aluminium, résistants aux vibrations. T°C',
            'ref': '12475683',
            'category': 'nautisme',
            'price': 35.99, 
            'quantity': 1
        },
        {
            'id': 'tennis1',
            'name': 'Raquette head',
            'image': 'Content/img/tennis1.jpg', 
            'description': 'Raquette de tennis adulte speed MP noir et blanc. Grâce la technologie avancée du Graphene 360, la nouvelle HEAD Speed MP offre une stabilité remarquable ainsi qu’un transfert d’énergie amélioré de la raquette vers la balle. ',
            'ref': '35496155',
            'category': 'tennis',
            'price': 210,
            'quantity': 1
        },
        {
            'id': 'tennis2',
            'name': 'Raquette Wilson Burn',
            'image': 'Content/img/tennis2.jpg', 
            'description': 'Raquette de tennis adulte burn 100 LS noir orange. Raquette idéale pour le joueur recherchant une raquette légère mais néanmoins puissante et avec une bonne prise d\'effet. ',
            'ref': '68764354',
            'category': 'tennis',
            'price': 140,
            'quantity': 1
        },
        {
            'id': 'tennis3',
            'name': 'Surgrip Artengo',
            'image': 'Content/img/tennis3.jpg', 
            'description': 'Ce surgrip, facile à poser sur le manche, vous apporte un excellent confort lorsque vous jouez. Il vous permettra d\'améliorer la préhension de votre raquette de Tennis ',
            'ref': '16465416',
            'category': 'tennis',
            'price': 4,
            'quantity': 1
        },
        {
            'id': 'tennis4',
            'name': 'Cordage Babolat',
            'image': 'Content/img/tennis4.jpg', 
            'description': 'Ce cordage de tennis monofilament Babolat RPM Blast 1,25mm vous procure prise d\'effet grâce à sa section octogonale et du contrôle.C’est le cordage choisi par Rafael Nadal, Jo-Wilfried Tsonga. ',
            'ref': '64516385',
            'category': 'tennis',
            'price': 160,
            'quantity': 1
        },
        {
            'id': 'tennis5',
            'name': 'Balles Roland Garros',
            'image': 'Content/img/tennis5.jpg', 
            'description': 'Balle pression performante conçue pour être utilisée sur tout type de surfaces. Cette balle apporte durée de vie, vivacité avec une grande jouabilité. La balle toutes surfaces de Roland Garros.',
            'ref': '7845221',
            'category': 'tennis',
            'price': 6,
            'quantity': 1
        },
        {
            'id': 'tennis6',
            'name': 'Sac de tennis Artengo',
            'image': 'Content/img/tennis6.jpg', 
            'description': 'Ce sac de tennis Artengo LB 960 possède une poche centrale thermo pour les raquettes, pour une meilleure protection contre les chocs(poche au centre) et contre les changements de températures..',
            'ref': '41651654',
            'category': 'tennis',
            'price': 65,
            'quantity': 1
        },
    ];
    // génération de la div mainContent avec tous les produits
    var items_length = items.length;
    for (var index = 0; index < items_length; index++) {
        $('.mainContent').append(
            '<div class="col-md-12 col-lg-4">'
            + '<div class="card mb-2" style="width: 22rem;" id="' + items[index]['id'] + '">'
            + '<img src="' + items[index]['image'] + '" class="card-img-top item-image" alt=""></img>'
            + '<div class="card-body">'
            + '<h5 class="card-title" id="item1-title">' + items[index]['name'] + '</h5>'
            + '<p class="card-text" id="item1-description">' + items[index]['description'] + '</p>'
            + '<p class="card-text" id="item1-price">Prix : ' + items[index]['price'] + ' €</p>'
            + '<footer class="blockquote-footer" id="item1-ref">' + items[index]['ref'] + '</footer>'
            + '<a sport="' + items[index]['id'] + '" href="#" id="' + index + '" class="btn btn-primary addToCart">Ajouter au panier</a>'
            + '</div>'
            + '</div>'
            + '</div>');
    };
    addToCart();
    // génération de la div mainContent avec seulement les produits de randonnée
    $('#rando').click(function () {
        event.preventDefault();
        $('.mainContent').empty();
        for (var index = 0; index < items_length; index++) {
            if (items[index].category == 'randonnée') {
                $('.mainContent').append(
                    '<div class="col-md-12 col-lg-4">'
                    + '<div class="card mb-2" style="width: 22rem;" id="' + items[index]['id'] + '">'
                    + '<img src="' + items[index]['image'] + '" class="card-img-top item-image" alt=""></img>'
                    + '<div class="card-body">'
                    + '<h5 class="card-title" id="item1-title">' + items[index]['name'] + '</h5>'
                    + '<p class="card-text" id="item1-description">' + items[index]['description'] + '</p>'
                    + '<p class="card-text" id="item1-price">Prix : ' + items[index]['price'] + ' €</p>'
                    + '<footer class="blockquote-footer" id="item1-ref">' + items[index]['ref'] + '</footer>'
                    + '<a sport="' + items[index]['id'] + '" href="#" id="' + index + '" class="btn btn-primary addToCart">Ajouter au panier</a>'
                    + '</div>'
                    + '</div>'
                    + '</div>');
            }
        };
        addToCart();
    });
    // génération de la div mainContent avec seulement les produits de nautisme
    $('#nautisme').click(function () {
        $('.mainContent').empty();
        event.preventDefault();
        for (var index = 0; index < items_length; index++) {
            if (items[index].category == 'nautisme') {
                $('.mainContent').append(
                    '<div class="col-md-12 col-lg-4">'
                    + '<div class="card mb-2" style="width: 22rem;" id="' + items[index]['id'] + '">'
                    + '<img src="' + items[index]['image'] + '" class="card-img-top item-image" alt=""></img>'
                    + '<div class="card-body">'
                    + '<h5 class="card-title" id="item1-title">' + items[index]['name'] + '</h5>'
                    + '<p class="card-text" id="item1-description">' + items[index]['description'] + '</p>'
                    + '<p class="card-text" id="item1-price">Prix : ' + items[index]['price'] + ' €</p>'
                    + '<footer class="blockquote-footer" id="item1-ref">' + items[index]['ref'] + '</footer>'
                    + '<a sport="' + items[index]['id'] + '" href="#" id="' + index + '" class="btn btn-primary addToCart">Ajouter au panier</a>'
                    + '</div>'
                    + '</div>'
                    + '</div>');
            }
        };
        addToCart();
    });
    // génération du contenu de mainContent avec seulement les produits de tennis
    $('#tennis').click(function () {
        $('.mainContent').empty();
        event.preventDefault();
        for (var index = 0; index < items_length; index++) {
            if (items[index].category == 'tennis') {
                $('.mainContent').append(
                    '<div class="col-md-12 col-lg-4">'
                    + '<div class="card mb-2" style="width: 22rem;" id="' + items[index]['id'] + '">'
                    + '<img src="' + items[index]['image'] + '" class="card-img-top item-image" alt=""></img>'
                    + '<div class="card-body">'
                    + '<h5 class="card-title" id="item1-title">' + items[index]['name'] + '</h5>'
                    + '<p class="card-text" id="item1-description">' + items[index]['description'] + '</p>'
                    + '<p class="card-text" id="item1-price">Prix : ' + items[index]['price'] + ' €</p>'
                    + '<footer class="blockquote-footer" id="item1-ref">' + items[index]['ref'] + '</footer>'
                    + '<a sport="' + items[index]['id'] + '" href="#" id="' + index + '" class="btn btn-primary addToCart">Ajouter au panier</a>'
                    + '</div>'
                    + '</div>'
                    + '</div>');
            }
        };
        addToCart();
    });
    // fonction d'ajout au panier
    function addToCart() {
        $('.addToCart').click(function () {
            var item = $(this).attr('sport');
            var item2 = $(this).attr('id');
            var exist = 0;
            var indexExist;
            console.log(cartContent);
            var cartContent_length = cartContent.length;
            if (cartContent_length == 0) {
                cartContent.push(items[item2]);
                swal("Merci!", "Produit ajouté au panier", "success");
            } else if (cartContent_length > 0) {
                $.each(cartContent, function (key) {
                    if (cartContent[key].id == item) {
                        exist++;
                        indexExist = key;
                    }
                });
                if (exist == 0) {
                    cartContent.push(items[item2]);
                    swal("Merci!", "Produit ajouté au panier", "success");
                } else if (exist == 1) {
                    cartContent[indexExist].quantity++;
                    swal('Produit déjà présent dans le panier, quantité augmentée.');
                }
            }
            event.preventDefault();
        });
    };
    // fonction d'affichage du tableau cartContent
    $('#openModal').click(function () {
        $('#cartModal').empty();
        if (Object.keys(cartContent).length > 0) {
            $.each(cartContent, function (key) {
                if (cartContent[key].name != undefined) {
                    $('#cartModal').append('<p id="remove' + key + '">'
                        + '<button class="deleteButton' + key + ' btn btn-danger">X</button>'
                        + cartContent[key].name
                        + '<span class="d-inline-block"><button class="remove-item' + key + ' btn btn-info"> -</button>'
                        + '<span class="quantity' + key + '">Quantités : ' + cartContent[key].quantity + '</span > '
                        + '<button class="add-item' + key + ' btn btn-info"> +</button></span>'
                        + '<span class="price' + key + ' d-inline-block">Prix : ' + cartContent[key].price * cartContent[key].quantity + '€' + '</span>'
                        + '</p>');
                    quantityChange(key);
                }
                // fonction delete pour supprimer un article du panier
                $('.deleteButton' + key).click(function () {
                    cartContent.splice(key, 1, '');
                    $('#remove' + key).remove();
                    $('#total').remove();
                    calcTotal();
                    if (Object.keys(cartContent).length == 0) {
                        $('#cartModal').append('<p>Votre panier est vide.</p>');
                    }
                });
            });
            calcTotal();
        } else {
            $('#cartModal').append('<p>Votre panier est vide.</p>');
        }
    });
    // fonction qui calcule et affiche le montant total du panier
    var calcTotal = function () {
        var total = 0;
        $(cartContent).each(function (key) {
            value = cartContent[key].price;
            quantity = cartContent[key].quantity;
            if (!isNaN(value)) {
                total = total + value * quantity;
            }
        });
        if (total > 0) {
            $('#cartModal').append('<p id="total" class="font-weight-bold">Total : ' + total + ' €.</p >');
        } else {
            $('#cartModal').append('<p>Votre panier est vide.</p>');
        }
    };
    //fonction pour changer la quantité
    function quantityChange(key) {
        $('.remove-item' + key).click(function () {
            cartContent[key].quantity--;
            $('.quantity' + key).text(`Quantités : ${cartContent[key].quantity}`);
            var price = cartContent[key].price * cartContent[key].quantity;
            $('.price' + key).text(`Prix : ${price} €.`);
            $('#total').remove();
            calcTotal();
            if (cartContent[key].quantity < 1) {
                cartContent.splice(key, 1, '');
                $('#remove' + key).remove();
                $('#total').remove();
                calcTotal();
            }
        });
        $('.add-item' + key).click(function () {
            cartContent[key].quantity++;
            $('.quantity' + key).text(`Quantités : ${cartContent[key].quantity}`);
            var price = cartContent[key].price * cartContent[key].quantity;
            $('.price' + key).text(`Prix : ${price} €.`);
            $('#total').remove();
            calcTotal();
        });
    };
    $('#buyButton').click(function () {
        if (Object.keys(cartContent).length > 0) {
            swal('Merci pour vos achats!');
        } else {
            swal('Votre panier est vide.');
        }
    });
});