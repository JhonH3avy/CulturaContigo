export interface ActivityCreateRequest {
  name: string;
  details: string;
  place: string | null;
  scheduledDateTime: string | null;
  ticketPrice: number | null;
  capacity: number | null;
  imageUrl: string | null;
}
