export class EncuestaCampo {
    idEncuestaCampo!: number;
    idEncuesta: number;
    titulo: string;
    nombre: string;
    requerido: boolean;

    constructor() {
        this.idEncuesta = 0;
        this.titulo = '';
        this.nombre = '';
        this.requerido = false;
    }
}

export class Encuesta {
    idEncuesta!: number;
    nombreEncuesta: string;
    descripcion: string;
    encuestaCampos: EncuestaCampo[];

    constructor() {
        this.nombreEncuesta = '',
        this.descripcion = '',
        this.encuestaCampos = []
    }
}