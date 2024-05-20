// src/app/components/encuesta-form/encuesta-form.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { EncuestaService } from '../../services/encuesta.service';
import { Encuesta } from '../../models/encuesta.model';
import { transformEncuesta } from '../../helpers/encuesta.helper';

@Component({
  selector: 'app-encuesta-form',
  templateUrl: './encuesta-form.component.html',
  styleUrls: ['./encuesta-form.component.css']
})
export class EncuestaFormComponent implements OnInit {
  encuestaForm: FormGroup;
  isEditMode: boolean = false;
  id!: number;

  constructor(
    private fb: FormBuilder,
    private encuestaService: EncuestaService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.encuestaForm = this.fb.group({
      idEncuesta: [0],
      nombreEncuesta: ['', Validators.required],
      descripcion: ['', Validators.required],
      encuestaCampos: this.fb.array([])
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
        const idParam = params.get('id');
        if (idParam) {
          this.id = +idParam;
          this.isEditMode = true;
          this.loadEncuesta(this.id);
        }
      });
  }

  loadEncuesta(id: number): void {
    this.encuestaService.getEncuesta(id).subscribe(data => {
      var dataConverted = transformEncuesta(data);
      this.encuestaForm.patchValue(dataConverted);
      console.log(dataConverted);
      this.encuestaForm.setControl('encuestaCampos', this.fb.array(dataConverted.encuestaCampos || []));
      console.log(this.encuestaForm);
    });
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.encuestaService.updateEncuesta(this.encuestaForm.value).subscribe(() => {
        this.router.navigate(['/encuestas']);
      });
    } else {
      this.encuestaService.createEncuesta(this.encuestaForm.value).subscribe(() => {
        this.router.navigate(['/encuestas']);
      });
    }
  }

  get encuestaCampos(): FormArray {
    return this.encuestaForm.get('encuestaCampos') as FormArray;
  }

  addCampo(): void {
    this.encuestaCampos.push(this.fb.group({
      idEncuestaCampo: [0],
      idEncuesta: [this.id],
      nombre: ['', Validators.required],
      titulo: ['', Validators.required],
      requerido: [false]
    }));
  }

  removeCampo(index: number): void {
    this.encuestaCampos.removeAt(index);
  }
}