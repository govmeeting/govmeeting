import { createMetadataMap, pojos } from '@automapper/pojos';
import { createMapper, CamelCaseNamingConvention, mapFrom } from '@automapper/core';

export interface Job {
  title: string;
  salary: number;
}

export interface Bio {
  jobs: Job[];
  birthday: Date;
  avatarUrl: string | undefined;
}

export interface User {
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  bio: Bio;
  gender: GenderType;
}

export interface JobDto {
  title: string;
  salary: number;
}

export interface BioDto {
  jobs: JobDto[];
  birthday: string;
  avatarUrl: string | undefined;
}

export interface UserDto {
  firstName: string;
  lastName: string;
  fullName: string;
  username: string;
  bio: BioDto;
  gender: GenderType;
}

export enum GenderType {
  unspecified = 0,
  male = 1,
  female = 2,
}

export class SampleMapper {
  mapper = createMapper({
    name: 'blah',
    pluginInitializer: pojos,
  });

  useMapper() {
    this.mapBio();

    this.mapUser();

    const user: User = this.getUser();

    const userDto = this.mapper.map(user, 'UserDto', 'User');
  }
  mapBio() {
    // Map "Job"
    createMetadataMap<Job>('Job', {
      title: String,
      salary: Number,
    });

    // "JobDto" contains same properties as "Job"
    createMetadataMap<JobDto>('JobDto', 'Job');

    // Map "Bio"
    createMetadataMap<Bio>('Bio', {
      jobs: 'Job',
      avatarUrl: String,
    });

    // "BioDto" is same as "Bio" but with different jobs.
    createMetadataMap<BioDto>('BioDto', 'Bio', {
      jobs: 'JobDto',
    });

    // Map "Job" to "JobDto" - all properties use conventions mapping.
    this.mapper.createMap<Job, JobDto>('Job', 'JobDto');

    // Map "Bio" to "BioDto" - birthday is Date in Bio, but string in BioDto
    this.mapper
      .createMap<Bio, BioDto>('Bio', 'BioDto', {
        namingConventions: new CamelCaseNamingConvention(),
      })
      .forMember(
        (destination) => destination.birthday,
        mapFrom((source) => source.birthday.toDateString())
      );
  }

  mapUser() {
    // Map "User"
    createMetadataMap<User>('User', {
      firstName: String,
      lastName: String,
      username: String,
      bio: 'Bio',
      gender: Number,
    });

    // "UserDto" is same as "User" but with different bio.
    createMetadataMap<UserDto>('UserDto', 'User', {
      bio: 'BioDto',
    });

    // Map User to UserDto. UserDto contains fullname.
    this.mapper.createMap<User, UserDto>('User', 'UserDto').forMember(
      (destination) => destination.fullName,
      mapFrom((source) => source.firstName + ' ' + source.lastName)
    );
  }

  getUser(): User {
    const user = {
      bio: {
        jobs: [
          {
            title: 'dev',
            salary: 1234567,
          },
          {
            title: 'mgr',
            salary: 7654321,
          },
        ],
        birthday: new Date(),
        avatarUrl: 'url.com',
      },
      firstName: 'Chau',
      lastName: 'Tran',
      username: 'ctran',
      password: '123456',
      gender: GenderType.male,
    } as User;
    return user;
  }
}
