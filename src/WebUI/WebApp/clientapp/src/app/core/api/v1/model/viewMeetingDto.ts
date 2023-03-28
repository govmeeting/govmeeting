/**
 * Govmeeting.api
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { ViewMeetingTopicDto } from './viewMeetingTopicDto';
import { ViewMeetingSpeakerDto } from './viewMeetingSpeakerDto';
import { ViewMeetingSectionDto } from './viewMeetingSectionDto';


export interface ViewMeetingDto { 
    meetingId?: number;
    govbodyName?: string | null;
    locationName?: string | null;
    date?: string | null;
    topics?: Array<ViewMeetingTopicDto> | null;
    speakers?: Array<ViewMeetingSpeakerDto> | null;
    sections?: Array<ViewMeetingSectionDto> | null;
}
