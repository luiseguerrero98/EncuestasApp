import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Encuesta } from '../models/encuesta.model';

@Injectable({
  providedIn: 'root'
})
export class EncuestaService {
  private apiUrl = 'http://localhost:5175/api/encuesta';

  constructor(private http: HttpClient) { }

  getEncuestas(): Observable<Encuesta[]> {
    return this.http.get<Encuesta[]>(this.apiUrl);
  }

  getEncuesta(id: number): Observable<Encuesta> {
    return this.http.get<Encuesta>(`${this.apiUrl}/${id}`);
  }

  createEncuesta(encuesta: Encuesta): Observable<Encuesta> {
    return this.http.post<Encuesta>(this.apiUrl, encuesta);
  }

  updateEncuesta(encuesta: Encuesta): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${encuesta.idEncuesta}`, encuesta);
  }

  deleteEncuesta(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}