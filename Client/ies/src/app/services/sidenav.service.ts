import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';


@Injectable()
export class SidenavService {
    private sidenav: MatSidenav | undefined;


    public setSidenav(sidenav: MatSidenav) {
        this.sidenav = sidenav;
    }

    public open() {
        return this.sidenav?.open();
    }

    public close() {
        return this.sidenav?.close();
    }

    public toggle(): void {
        this.sidenav?.toggle();
    }

    public opened(): boolean{
        return this.sidenav?.opened ?? false
    }
}