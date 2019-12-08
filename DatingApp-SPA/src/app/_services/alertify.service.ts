import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';
import { stringify } from 'querystring';


@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor(){}

  confirm(message: string, okCallback: () => any){ // ta drugi parameter pove da metoda vzame funkcijo, ki vrne tip any (karkoli torej) in je realizirana v modulu
    alertify(message, (e: any) => { // e je dogodek potrditve uporabnika
      if (e) {
        okCallback();
      } else {}
    })
  }

  success(message: string){
    alertify.success(message);
  }

  error(message: string){
    alertify.error(message);
  }

  warning(message: string){
    alertify.warning(message);
  }

  message(message: string){
    alertify.message(message);
  }
}

