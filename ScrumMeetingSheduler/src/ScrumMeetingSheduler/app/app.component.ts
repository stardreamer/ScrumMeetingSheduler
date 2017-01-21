import { Component } from '@angular/core';

@Component({
    moduleId: module.id,    
    selector: 'sheduler-app',
    template: `
        <nav>
            <a routerLink="/pairing" routerLinkActive="active">Pairing</a> | 
            <a routerLink="/about" routerLinkActive="active">About</a>            
        </nav>
        <router-outlet></router-outlet>
    `,
})
export class AppComponent {
}