import {Injectable} from 'angular2/core';

export interface IUserChoiceSrv {
    getSpeaker(): string;
    setSpeaker(speaker: string): void;
    getTopic(): string;
    setTopic(topic: string): void;
}

    /**
     * <summary>
     *  A user choice server.
     * </summary>
    **/

@Injectable()
export class UserchoiceService implements IUserChoiceSrv {

    _speaker : string;
    _topic: string;

    constructor() {
    }

    /**
     * <summary>
     *  Gets the speaker.
     * </summary>
     * <returns>
     *  The speaker.
     * </returns>
    **/
    getSpeaker() : string {
        // console.log("getSpeaker=" + this._speaker)
        return this._speaker;
    }

    /**
     * <summary>
     *  Sets a speaker.
     * </summary>
     * <param name="speaker">   The speaker. </param>
     * <returns>
     *  .
     * </returns>
    **/
    setSpeaker(speaker : string) {
        console.log("setSpeaker=" + speaker)
        this._speaker = speaker;
    }

    /**
     * <summary>
     *  Gets the topic.
     * </summary>
     * <returns>
     *  The topic.
     * </returns>
    **/
    getTopic() : string {
        // console.log("getTopic=" + this._topic)
        return this._topic;
    }

    /**
     * <summary>
     *  Sets a topic.
     * </summary>
     * <param name="topic"> The topic. </param>
     * <returns>
     *  .
     * </returns>
    **/
    setTopic(topic: string) {
        console.log("setTopic=" + topic)
        this._topic = topic;
    }
}
