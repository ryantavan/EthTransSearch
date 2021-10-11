import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchComponent } from './search/search.component';
import { SpinnerComponent } from "./tools/spinner/spinner.component";
import { NumberDirective } from "./directives/numbers-only.directive";
import { AlertModule } from './tools/alert';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SearchComponent,
    SpinnerComponent,
    NumberDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AlertModule,
    RouterModule.forRoot([
      { path: '', component: SearchComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
