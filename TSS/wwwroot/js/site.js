//menu
document.addEventListener('DOMContentLoaded', function () {
    const navEl = document.querySelector('.navbar');

    window.addEventListener('scroll', function () {
        if (window.scrollY > 200) {
            navEl.classList.add('navbar-scrolled');
        } else {
            navEl.classList.remove('navbar-scrolled');
        }
    });

    // init Isotope
    var $grid = $('#product-list').isotope({});

    // filter items on button click
    $('.filter-button-group').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({ filter: filterValue });
    });

    // AOS
    AOS.init({
        duration: 1800,
    });

    // Swiper initialization
    var swiper = new Swiper('.aboutInner', {
        slidesPerView: 2,
        spaceBetween: 15,
        slidesPerGroup: 2,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
        },
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        breakpoints: {
            768: {
                slidesPerView: 1,
                slidesPerGroup: 1,
            },
            769: {
                slidesPerView: 2,
                slidesPerGroup: 2,
            }
        }
    });

    function validarCPF(cpf) {
        cpf = cpf.replace(/[^\d]+/g, '');
        if (cpf.length !== 11) return false;
        if (/^(\d)\1+$/.test(cpf)) return false;

        let soma = 0, resto;
        for (let i = 1; i <= 9; i++) soma += parseInt(cpf.substring(i - 1, i)) * (11 - i);
        resto = (soma * 10) % 11;
        if ((resto == 10) || (resto == 11)) resto = 0;
        if (resto != parseInt(cpf.substring(9, 10))) return false;

        soma = 0;
        for (let i = 1; i <= 10; i++) soma += parseInt(cpf.substring(i - 1, i)) * (12 - i);
        resto = (soma * 10) % 11;
        if ((resto == 10) || (resto == 11)) resto = 0;
        if (resto != parseInt(cpf.substring(10, 11))) return false;

        return true;
    }

    function validarCNPJ(cnpj) {
        cnpj = cnpj.replace(/[^\d]+/g, '');
        if (cnpj.length !== 14) return false;
        if (/^(\d)\1+$/.test(cnpj)) return false;

        let tamanho = cnpj.length - 2;
        let numeros = cnpj.substring(0, tamanho);
        let digitos = cnpj.substring(tamanho);
        let soma = 0;
        let pos = tamanho - 7;
        for (let i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2) pos = 9;
        }
        let resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) return false;

        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (let i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2) pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) return false;

        return true;
    }

    function validarFormulario() {
        const cpfCnpj = document.getElementById('cpf_cnpj').value;
        const cpfCnpjError = document.getElementById('cpfCnpjError');

        if (cpfCnpj.length === 14) {
            if (!validarCPF(cpfCnpj)) {
                cpfCnpjError.textContent = 'CPF inválido';
                cpfCnpjError.style.display = 'block';
                return false;
            }
        } else if (cpfCnpj.length === 18) {
            if (!validarCNPJ(cpfCnpj)) {
                cpfCnpjError.textContent = 'CNPJ inválido';
                cpfCnpjError.style.display = 'block';
                return false;
            }
        } else {
            cpfCnpjError.textContent = 'CPF/CNPJ inválido';
            cpfCnpjError.style.display = 'block';
            return false;
        }

        cpfCnpjError.style.display = 'none';
        return true;
    }

    $(document).ready(function () {
        // Inicialmente, esconde o campo de CPF/CNPJ
        $('#cpf_cnpj').hide();

        // Ao clicar no botão CPF
        $('#cpfBtn').click(function () {
            $('#cpf_cnpj').unmask();
            $('#cpf_cnpj').mask('000.000.000-00');
            $('#cpfBtn').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#cnpjBtn').removeClass('btn-primary').addClass('btn-outline-primary');
            $('#cpf_cnpj').show().focus(); // Mostra o campo e foca nele
        });

        // Ao clicar no botão CNPJ
        $('#cnpjBtn').click(function () {
            $('#cpf_cnpj').unmask();
            $('#cpf_cnpj').mask('00.000.000/0000-00');
            $('#cnpjBtn').addClass('btn-primary').removeClass('btn-outline-primary');
            $('#cpfBtn').removeClass('btn-primary').addClass('btn-outline-primary');
            $('#cpf_cnpj').show().focus(); // Mostra o campo e foca nele
        });

        // Máscara para telefone
        $('#telefone').mask('(00)00000-0000');
    });
});
