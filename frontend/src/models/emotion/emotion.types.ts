import { z } from 'zod'

import {
	BaseEmotionSchema,
	EmotionSchema,
} from '~models/emotion/emotion.schema'

export type IEmotion = z.infer<typeof EmotionSchema>

export type ICreateEmotion = z.infer<typeof BaseEmotionSchema>

export type IUpdateEmotion = z.infer<typeof BaseEmotionSchema>

export type UseEmotions = UseModelOptions
