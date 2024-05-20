import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { EncuestaService } from '../../services/encuesta.service';
import { Encuesta } from '../../models/encuesta.model';
import { transformEncuestas } from '../../helpers/encuesta.helper';

@Component({
  selector: 'app-encuesta-list',
  templateUrl: './encuesta-list.component.html',
  styleUrls: ['./encuesta-list.component.css']
})
export class EncuestaListComponent implements OnInit {
  encuestas: Encuesta[] = [];

  constructor(private encuestaService: EncuestaService, private router: Router) { }

  ngOnInit(): void {
    this.loadEncuestas();
  }

  loadEncuestas(): void {
    this.encuestaService.getEncuestas().subscribe(data => {
      this.encuestas = transformEncuestas(data);
    });
  }

  deleteEncuesta(id: number): void {
    this.encuestaService.deleteEncuesta(id).subscribe(() => {
      this.loadEncuestas();
    });
  }
   navigateToCreate(): void {
    this.router.navigate(['/encuestas/new']);
  }
  
   navigateToEdit(id: number): void {
    this.router.navigate(['/encuestas/edit', id]);
  }

  // transformEncuestas(response: any): Encuesta[] {
  //   const encuestas: Encuesta[] = response.$values.map((encuesta: any) => {
  //     return {
  //       id: encuesta.idEncuesta,
  //       titulo: encuesta.nombreEncuesta,
  //       descripcion: encuesta.descripcion,
  //       encuestaCampos: encuesta.encuestaCampos.$values.map((campo: any) => ({
  //         idEncuestaCampo: campo.idEncuestaCampo,
  //         idEncuesta: campo.idEncuesta,
  //         nombre: campo.nombre,
  //         titulo: campo.titulo,
  //         requerido: campo.requerido
  //       }))
  //     };
  //   });
  //   return encuestas;
  // }
}