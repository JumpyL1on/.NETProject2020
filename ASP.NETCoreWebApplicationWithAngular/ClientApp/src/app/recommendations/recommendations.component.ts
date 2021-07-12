import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthorizeService } from "../../api-authorization/authorize.service";

@Component({
  selector: 'app-recommendations',
  templateUrl: './recommendations.component.html',
  styleUrls: ['./recommendations.component.css']
})

export class RecommendationsComponent implements OnInit {
  recommendations: Observable<Recommendation[]>;
  isAdmin: Observable<boolean>;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private authorizeService: AuthorizeService) {
    this.isAdmin = this.authorizeService
      .getUser()
      .pipe(map(u => u && u.name == "admin@gmail.com"));
    this.recommendations = this.http.get<Recommendation[]>(this.baseUrl + 'api/Recommendation');
  }

  ngOnInit() {
  }

  Update(recommendation: Recommendation): void {
    let updateRecommendationCommand = <UpdateRecommendationCommand>{
      id: recommendation.id,
      content: recommendation.content
    }
    this.http
      .put<Recommendation>(this.baseUrl + "api/Recommendation", updateRecommendationCommand)
      .subscribe();
  }
}

interface Recommendation {
  id: number,
  content: string;
}

interface UpdateRecommendationCommand {
  id: number,
  content: string
}
