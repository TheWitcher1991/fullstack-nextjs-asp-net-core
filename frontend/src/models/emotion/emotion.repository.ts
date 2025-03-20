import { emotionServiceKeys } from '~models/emotion/emotion.config'
import {
	ICreateEmotion,
	IEmotion,
	IUpdateEmotion,
	UseEmotions,
} from '~models/emotion/emotion.types'

import { http } from '~packages/lib'
import { CrudRepository } from '~packages/mixins'

const EmotionRepositoryBuilder = () => {
	return new CrudRepository<
		IEmotion[],
		IEmotion,
		ICreateEmotion,
		IUpdateEmotion,
		UseEmotions
	>(http.instance, emotionServiceKeys.emotions)
}

export const EmotionRepository = EmotionRepositoryBuilder()
