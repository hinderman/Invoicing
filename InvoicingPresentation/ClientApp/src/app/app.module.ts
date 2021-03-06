import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { DxButtonModule, DxFormModule } from "devextreme-angular";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing.module";
import { SharedModule } from "./shared/shared.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  schemas: [],
  imports: [
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    FormsModule,
    DxButtonModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule,
    SharedModule,
    DxFormModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
