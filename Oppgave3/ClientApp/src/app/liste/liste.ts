import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { Faq } from "../Faq";

@Component({
  templateUrl: "liste.html"
})
export class Liste {
  allFaqs: Array<Faq>;
  laster: boolean;
  kundeTilSletting: string;
  slettingOK: boolean;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleKunder();
  }

  hentAlleKunder() {
    this.http.get<Faq[]>("api/faq/")
      .subscribe(faqs => {
        this.allFaqs = faqs;
        this.laster = false;
        console.log("downvotes: "+this.allFaqs[0].downVotes);
      },
       error => console.log(error)
      );
  };

  
}
