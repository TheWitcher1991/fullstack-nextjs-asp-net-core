import { topicServiceKeys } from '~models/topic/topic.config'
import {
	ICreateTopic,
	ITopic,
	IUpdateTopic,
	UseTopics,
} from '~models/topic/topic.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'

const TopicRepositoryBuilder = () => {
	return new CrudRepository<
		ITopic[],
		ITopic,
		ICreateTopic,
		IUpdateTopic,
		UseTopics
	>(http.instance, topicServiceKeys.topics)
}

export const TopicRepository = TopicRepositoryBuilder()
