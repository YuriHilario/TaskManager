import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app'; // <- Corrigido aqui: App em vez de AppComponent
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { TokenInterceptor } from './app/interceptors/token-interceptor';

bootstrapApplication(App, {
  providers: [
    provideHttpClient(withInterceptors([TokenInterceptor])),
    importProvidersFrom(BrowserAnimationsModule),
    provideRouter(routes),
  ]
});
