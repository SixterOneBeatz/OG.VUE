var app = new Vue({
    el: '#app',
    data: {
        mensaje: "Hola mundo desde vue.js",
        lista: [],
        idPersona: 0,
        newNombre: "",
        newEdad: 0
    },
    created: function () {
        this.getPersonas();
    },
    methods: {
        getPersonas: function () {
            this.lista = [];
            this.$http.get('../Home/GetPersonas')
                .then(function (response) {
                    this.lista = response.body
                });
        },
        addPersona: function () {
            if (this.idPersona != 0) {
                if (this.newEdad != 0 && this.newNombre != "") {
                    let Persona = { Id: this.idPersona, Nombre: this.newNombre, Edad: this.newEdad }
                    this.$http.post('../Home/UpdatePersonas', Persona, { emulateJSON: true })
                        .then(function (response) {
                            this.lista = [];
                            this.lista = response.body;
                            this.idPersona = 0;
                            this.newNombre = "";
                            this.newEdad = 0;
                        });
                }
            }
            else {
                if (this.newEdad != 0 && this.newNombre != "") {
                    let Persona = { Nombre: this.newNombre, Edad: this.newEdad }
                    this.$http.post('../Home/AddPersonas', Persona, { emulateJSON: true })
                        .then(function (response) {
                            this.lista = [];
                            this.lista = response.body;
                            this.idPersona = 0;
                            this.newNombre = "";
                            this.newEdad = 0;
                        });
                }
            }
        },
        deletePersonas: function (id) {

            this.$http.get('../Home/DeletePersonas/' + id)
                .then(function (response) {
                    this.lista = [];
                    this.lista = response.body
                });

        },
        editPersonas: function (item) {
            this.newNombre = item.Nombre;
            this.newEdad = item.Edad;
            this.idPersona = item.Id;
        },
        limpiar: function () {
            this.idPersona = 0;
            this.newNombre = "";
            this.newEdad = 0;
        }
    }
});
