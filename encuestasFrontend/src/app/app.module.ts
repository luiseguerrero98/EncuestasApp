import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app.config'; // Ensure this import points to your app.config.ts
import { EncuestaListComponent } from './components/encuesta-list/encuesta-list.component';
import { EncuestaFormComponent } from './components/encuesta-form/encuesta-form.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    EncuestaListComponent,
    EncuestaFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {// Add an empty ngDoBootstrap method
  }

