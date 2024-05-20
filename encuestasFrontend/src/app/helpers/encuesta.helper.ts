import { Encuesta } from '../models/encuesta.model';

export function transformEncuestas(response: any): Encuesta[] {
  const encuestas: Encuesta[] = response.$values.map((encuesta: any) => {
    return {
      idEncuesta: encuesta.idEncuesta,
      nombreEncuesta: encuesta.nombreEncuesta,
      descripcion: encuesta.descripcion,
      encuestaCampos: encuesta.encuestaCampos.$values.map((campo: any) => ({
        idEncuestaCampo: campo.idEncuestaCampo,
        idEncuesta: campo.idEncuesta,
        nombre: campo.nombre,
        titulo: campo.titulo,
        requerido: campo.requerido
      }))
    };
  });
  return encuestas;
}

export function transformEncuesta(response: any): Encuesta {
  const encuesta: Encuesta = {
      idEncuesta: response.idEncuesta,
      nombreEncuesta: response.nombreEncuesta,
      descripcion: response.descripcion,
      encuestaCampos: response.encuestaCampos.$values.map((campo: any) => ({
        idEncuestaCampo: campo.idEncuestaCampo,
        idEncuesta: campo.idEncuesta,
        nombre: campo.nombre,
        titulo: campo.titulo,
        requerido: campo.requerido
      }))

  }
  return encuesta;
}

