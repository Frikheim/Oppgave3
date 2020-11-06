import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Faq } from "../Faq";

@Component({
  templateUrl: "lagre.html"
})
export class Lagre {
  skjema: FormGroup;
  
  validering = {
    category: [
      null, Validators.compose([Validators.required, Validators.pattern("[a - zA - ZæøåÆØÅ ? !,.\-]{ 2, 250}")])
    ],
    question: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ]
  }

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.skjema = fb.group(this.validering);
  }

  vedSubmit() {
      this.lagreFaq();
  }

  lagreFaq() {
    const newFaq = new Faq;

    console.log("q: " + this.skjema.value.question + " c: " + this.skjema.value.category);

    newFaq.question = this.skjema.value.question;
    newFaq.category = this.skjema.value.category;
    newFaq.upVotes = 0;
    newFaq.downVotes = 0;

    this.http.post("api/faq", newFaq)
      .subscribe(retur => {
        this.router.navigate(['/liste']);
      },
       error => console.log(error)
      );
  };
}
