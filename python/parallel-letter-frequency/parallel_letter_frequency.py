import threading

THREAD_COUNT = 8


class LetterCounterThread(threading.Thread):
    lock = threading.Lock()

    def __init__(self, counter, letters):
        threading.Thread.__init__(self)
        self.counter = counter
        self.letters = letters

    def run(self):
        for letter in self.letters:
            if letter.isalpha():
                LetterCounterThread.lock.acquire()
                try:
                    self.counter[letter] += 1
                except KeyError:
                    self.counter[letter] = 1
                LetterCounterThread.lock.release()


def calculate(text_input):
    counts = {}
    clean = ''.join(text_input).lower()
    threads = []
    thread_count = min(len(clean), THREAD_COUNT)
    block_size = int(len(clean) / thread_count)
    if len(clean) % thread_count != 0:
        block_size += 1
    start = 0
    stop = block_size
    for i in range(thread_count):
        threads.append(LetterCounterThread(counts, clean[start:stop]))
        start = stop
        stop += block_size
    for thread in threads:
        thread.start()
    for thread in threads:
        thread.join()
    return counts
