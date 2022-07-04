export interface IPlacesResponse {
  type:        string;
  query:       number[];
  features:    Feature[];
  attribution: string;
}

export interface Feature {
  id:          string;
  type:        string;
  placeType:   string[];
  relevance:   number;
  properties:  Properties;
  text_es:      string;
  placeNameEs: string;
  text:        string;
  place_name:   string;
  center:      number[];
  geometry:    Geometry;
  address:     string;
  context:     Context[];
}

export interface Context {
  id:          string;
  textEs:      string;
  text:        string;
  shortCode?:  string;
  wikidata?:   string;
  languageEs?: string;
  language?:   string;
}

export interface Geometry {
  type:        string;
  coordinates: number[];
}

export interface Properties {
  accuracy: string;
}
